namespace MiniORM
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> initialEntities;

        private readonly List<T> addedEntities;

        private readonly List<T> removedEntities;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.addedEntities = new List<T>();
            this.removedEntities = new List<T>();

            this.initialEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> InitalEntities => this.initialEntities.AsReadOnly();

        public IReadOnlyCollection<T> AddedEntites => this.addedEntities.AsReadOnly();

        public IReadOnlyCollection<T> RemovedEntites => this.removedEntities.AsReadOnly();

        public void AddEntity(T entity) => this.addedEntities.Add(entity);

        public void RemoveEntity(T entity) => this.removedEntities.Add(entity);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var modifiedEntities = new List<T>();

            var primaryKeys = typeof(T)
                .GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxyEntity in this.InitalEntities)
            {
                var primaryKeysValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();

                var dbSetEntity = dbSet
                    .Entities
                    .FirstOrDefault(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeysValues));

                var isModifies = IsEntityModified(dbSetEntity, proxyEntity);

                if (isModifies)
                {
                    modifiedEntities.Add(dbSetEntity);
                }
            }

            return modifiedEntities;
        }

        private static bool IsEntityModified(T dbSetEntity, T proxyEntity)
        {
            if (dbSetEntity == null) return false;

            var validSqlProperties = typeof(T)
                .GetProperties()
                .Where(pi => DbContext.AllowedSqlEntites.Contains(pi.PropertyType))
                .ToArray();

            var modifiedProperties = validSqlProperties
                .Where(pi => !Equals(pi.GetValue(dbSetEntity), pi.GetValue(proxyEntity)))
                .ToArray();

            return modifiedProperties.Any();
        }

        private IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T proxyEntity)
        {
            return primaryKeys.Select(pk => pk.GetValue(proxyEntity));
        }

        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            var validSqlPropertiesToCloned = typeof(T)
                .GetProperties()
                .Where(pi => DbContext.AllowedSqlEntites.Contains(pi.PropertyType))
                .ToArray();

            foreach (var entity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();

                foreach (var property in validSqlPropertiesToCloned)
                {
                    var valueToSet = property.GetValue(entity);
                    property.SetValue(clonedEntity, valueToSet);
                }

                clonedEntities.Add(clonedEntity);
            }

            return clonedEntities;
        }
    }
}