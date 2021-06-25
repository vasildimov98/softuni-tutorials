namespace MiniORM
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.allEntities = CloneEntities(entities);

            this.added = new List<T>();
            this.removed = new List<T>();
        }

        public IReadOnlyCollection<T> AllEntities => this.allEntities.AsReadOnly();
        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();
        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();

        public void Add(T item) => this.added.Add(item);
        public void Remove(T item) => this.removed.Add(item);

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var modifiedEntities = new List<T>();

            var primaryKeys = typeof(T)
                .GetProperties()
                .Where(p => p.HasAttribute<KeyAttribute>())
                .ToArray();

            foreach (var proxyEntity in allEntities)
            {
                var primiryKeysValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();

                var entity = dbSet
                    .Entities
                    .Single(e => GetPrimaryKeyValues(primaryKeys, e)
                        .SequenceEqual(primiryKeysValues));

                var isModified = IsModified(proxyEntity, entity);

                if (isModified)
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }

        private static bool IsModified(T proxyEntity, T entity)
        {
            var monitoredProperties = typeof(T)
                .GetProperties()
                .Where(p => DbContext.AllowedSqlTypes.Contains(p.PropertyType))
                .ToArray();

            var modifiedEntities = monitoredProperties
                .Where(p => !Equals(p.GetValue(proxyEntity), p.GetValue(entity)))
                .ToArray();

            return modifiedEntities.Any();
        }

        private static IEnumerable<object> GetPrimaryKeyValues(System.Reflection.PropertyInfo[] primaryKeys, T proxyEntity)
            => primaryKeys.Select(p => p.GetValue(proxyEntity));

        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            var propertiesToClone = typeof(T)
                .GetProperties()
                .Where(p => DbContext.AllowedSqlTypes.Contains(p.PropertyType))
                .ToArray();

            foreach (var entity in entities)
            {
                var cloneEntity = Activator.CreateInstance<T>();

                foreach (var property in propertiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(cloneEntity, value);
                }

                clonedEntities.Add(cloneEntity);
            }

            return clonedEntities;
        }
    }
}