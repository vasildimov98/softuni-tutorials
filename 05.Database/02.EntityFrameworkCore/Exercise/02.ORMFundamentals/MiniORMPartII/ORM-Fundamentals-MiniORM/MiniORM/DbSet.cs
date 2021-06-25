namespace MiniORM
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class DbSet<TEntity> : ICollection<TEntity>
        where TEntity : class, new()
    {
        internal DbSet(IEnumerable<TEntity> entities)
        {
            this.ChangeTracker = new ChangeTracker<TEntity>(entities);

            this.Entities = entities.ToList();
        }

        internal ChangeTracker<TEntity> ChangeTracker { get; set; }

        internal IList<TEntity> Entities { get; set; }

        public int Count => this.Entities.Count;

        public bool IsReadOnly => this.Entities.IsReadOnly;

        public void Add(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException("Item cannot be null");

            this.Entities.Add(item);

            this.ChangeTracker.AddEntity(item);
        }

        public void Clear()
        {
            while (this.Entities.Any())
            {
                this.Remove(this.Entities.First());
            }
        }

        public bool Contains(TEntity item)
            => this.Entities.Contains(item);

        public void CopyTo(TEntity[] array, int arrayIndex)
            => this.Entities.CopyTo(array, arrayIndex);

        public bool Remove(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException("Item cannot be null");

            var isRemoved = this.Entities.Remove(item);

            if (isRemoved)
                this.ChangeTracker.RemoveEntity(item);

            return isRemoved;
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.Remove(entity);
            }
        }

        public IEnumerator<TEntity> GetEnumerator()
            => this.Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}