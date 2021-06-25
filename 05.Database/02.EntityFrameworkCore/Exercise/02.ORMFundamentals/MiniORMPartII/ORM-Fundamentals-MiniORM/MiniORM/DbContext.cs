namespace MiniORM
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;

    public abstract class DbContext
    {
        private readonly DatabaseConnection connection;

        private readonly Dictionary<Type, PropertyInfo> dbSetPropertiesByTypes;

        internal static readonly Type[] AllowedSqlEntites =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(double),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime),
        };

        protected DbContext(string connectionString)
        {
            this.connection = new DatabaseConnection(connectionString);

            this.dbSetPropertiesByTypes = this.DiscoverDbSetProperties();

            using (new ConnectionManager(this.connection))
            {
                this.InitializeDbSetProperties();
            }

            this.MapAllRealtions();
        }

        public void SaveChanges()
        {
            var dbSets = this.dbSetPropertiesByTypes
                .Select(pi => pi.Value.GetValue(this))
                .ToArray();

            foreach (IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet
                    .Where(en => !IsObjectValied(en))
                    .ToArray();

                if (invalidEntities.Any())
                    throw new InvalidOperationException($"{invalidEntities.Length} Invalid Entities found in {dbSet.GetType().Name}!");
            }

            using (new ConnectionManager(this.connection))
            {
                using (var transaction = this.connection.StartTransaction())
                {
                    foreach (IEnumerable dbSet in dbSets)
                    {
                        var dbSetTypeArgumet = dbSet.GetType().GetGenericArguments().First();

                        var persistMethod = typeof(DbContext)
                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                            .MakeGenericMethod(dbSetTypeArgumet);

                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch (TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        }
                        catch (InvalidOperationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }

                    transaction.Commit();
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var tableName = GetTableName(typeof(TEntity));

            var tableColums = this.connection.FetchColumnNames(tableName).ToArray();

            if (dbSet.ChangeTracker.AddedEntites.Any())
            {
                this.connection.InsertEntities(dbSet.ChangeTracker.AddedEntites, tableName, tableColums);
            }

            var modifiedEntities = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();
            if (modifiedEntities.Any())
            {
                this.connection.UpdateEntities(modifiedEntities, tableName, tableColums);
            }

            if (dbSet.ChangeTracker.RemovedEntites.Any())
            {
                this.connection.DeleteEntities(dbSet.ChangeTracker.RemovedEntites, tableName, tableColums);
            }
        }

        private void InitializeDbSetProperties()
        {
            foreach (var dbSetByPropertyType in dbSetPropertiesByTypes)
            {
                var propertyType = dbSetByPropertyType.Key;
                var propertyInfo = dbSetByPropertyType.Value;

                var populateDbSetMethod = typeof(DbContext)
                    .GetMethod("PopulateDbSet", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(propertyType);

                populateDbSetMethod.Invoke(this, new object[] { propertyInfo });
            }
        }

        private void PopulateDbSet<TEntity>(PropertyInfo propertyInfo)
            where TEntity : class, new()
        {
            var entities = this.LoadTableEntities<TEntity>();

            var dbSetInstance = new DbSet<TEntity>(entities);
            ReflectionHelper.ReplaceBackingField(this, propertyInfo.Name, dbSetInstance);
        }

        private void MapAllRealtions()
        {
            foreach (var dbSetPropertyByType in dbSetPropertiesByTypes)
            {
                var propertyType = dbSetPropertyByType.Key;
                var propertyValue = dbSetPropertyByType.Value.GetValue(this);

                var mapRelationsMethod = typeof(DbContext)
                    .GetMethod("MapRelations", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(propertyType);

                mapRelationsMethod.Invoke(this, new object[] { propertyValue });
            }
        }

        private void MapRelations<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var entityType = typeof(TEntity);

            this.MapNavigationProperties(dbSet);

            var collections = entityType
                .GetProperties()
                .Where(pi =>
                    pi.PropertyType.IsGenericType &&
                    pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>))
                .ToArray();

            foreach (var collection in collections)
            {
                var collectionGenericArgumet = collection.PropertyType.GetGenericArguments().First();

                var mapCollectionMethod = typeof(DbContext)
                    .GetMethod("MapCollection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .MakeGenericMethod(entityType, collectionGenericArgumet);

                mapCollectionMethod.Invoke(this, new object[] { dbSet, collection });
            }
        }

        private void MapCollection<TDbSet, TCollection>(DbSet<TDbSet> dbSet, PropertyInfo propertyInfo)
            where TDbSet : class, new()
            where TCollection : class, new()
        {
            var entityType = typeof(TDbSet);
            var collectionType = typeof(TCollection);

            var primaryKeys = collectionType
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            var foreignKey = entityType
                .GetProperties()
                .First(pi => pi.HasAttribute<KeyAttribute>());

            var primaryKey = primaryKeys.First();

            var isManyToManyRelation = primaryKeys.Length >= 2;
            if (isManyToManyRelation)
            {
                primaryKey = collectionType
                    .GetProperties()
                    .First(pi => collectionType
                                        .GetProperty(pi.GetCustomAttribute<ForeignKeyAttribute>().Name)
                                        .PropertyType == entityType);
            }

            var navigationDbSet = (DbSet<TCollection>)this.dbSetPropertiesByTypes[collectionType].GetValue(this);

            foreach (var entity in dbSet)
            {
                var primaryKeyValue = foreignKey.GetValue(entity);

                var navigationEntities = navigationDbSet
                    .Where(ne => primaryKey.GetValue(ne).Equals(primaryKeyValue))
                    .ToArray();

                ReflectionHelper.ReplaceBackingField(entity, propertyInfo.Name, navigationEntities);
            }
        }

        private void MapNavigationProperties<TEntity>(DbSet<TEntity> dbSet)
            where TEntity : class, new()
        {
            var entityType = typeof(TEntity);

            var foreignKeys = entityType
                .GetProperties()
                .Where(pi => pi.HasAttribute<ForeignKeyAttribute>())
                .ToArray();

            foreach (var foreignKey in foreignKeys)
            {
                var navigationPropertyName = foreignKey
                    .GetCustomAttribute<ForeignKeyAttribute>().Name;

                var navigationProperty = entityType.GetProperty(navigationPropertyName);

                var navigationDbSet = dbSetPropertiesByTypes[navigationProperty.PropertyType]
                    .GetValue(this);

                var navigationPrimaryKey = navigationProperty
                    .PropertyType
                    .GetProperties()
                    .First(pi => pi.HasAttribute<KeyAttribute>());

                foreach (var entity in dbSet)
                {
                    var primaryKeyValue = foreignKey.GetValue(entity);

                    var navigationPropertyValue = ((IEnumerable<object>)navigationDbSet)
                        .First(currNavigationProperty =>
                            navigationPrimaryKey.GetValue(currNavigationProperty).Equals(primaryKeyValue));

                    navigationProperty.SetValue(entity, navigationPropertyValue);
                }
            }
        }

        private bool IsObjectValied(object en)
        {
            var validationContext = new ValidationContext(en);
            var validationErrors = new List<ValidationResult>();

            var validationResult = Validator.TryValidateObject(en, validationContext, validationErrors, true);

            return validationResult;
        }

        private IEnumerable<TEntity> LoadTableEntities<TEntity>()
            where TEntity : class
        {
            var entityType = typeof(TEntity);

            var tableName = GetTableName(entityType);

            var columsNames = GetEntityColumnNames(entityType);

            var fetchedRows = this.connection.FetchResultSet<TEntity>(tableName, columsNames).ToArray();

            return fetchedRows;
        }

        private string[] GetEntityColumnNames(Type entityType)
        {
            var tableName = this.GetTableName(entityType);
            var dbTableColums = this.connection.FetchColumnNames(tableName);

            var validSqlColums = entityType
                .GetProperties()
                .Where(pi => !pi.HasAttribute<NotMappedAttribute>() &&
                              dbTableColums.Contains(pi.Name) &&
                              AllowedSqlEntites.Contains(pi.PropertyType))
                .Select(pi => pi.Name)
                .ToArray();

            return validSqlColums;
        }

        private string GetTableName(Type entityType)
        {
            var tableName = ((TableAttribute)Attribute.GetCustomAttribute(entityType, typeof(TableAttribute)))?.Name;

            if (tableName == null)
            {
                tableName = dbSetPropertiesByTypes[entityType].Name;
            }

            return tableName;
        }

        private Dictionary<Type, PropertyInfo> DiscoverDbSetProperties()
        {
            var output = this.GetType()
                .GetProperties()
                .Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToDictionary(pi => pi.PropertyType.GetGenericArguments().First(), pi => pi);

            return output;
        }
    }
}