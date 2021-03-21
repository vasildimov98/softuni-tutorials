namespace _02.Data
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    using Models;
    using Interfaces;

    public class Data : IRepository
    {
        private readonly OrderedBag<IEntity> entities;

        public Data()
        {
            this.entities = new OrderedBag<IEntity>();
        }

        public Data(OrderedBag<IEntity> entities)
        {
            this.entities = entities;
        }

        public int Size => this.entities.Count;

        public void Add(IEntity entity)
        {
            this.entities.Add(entity);

            var entityParent = this.GetById((int)entity.ParentId);

            if (entityParent != null)
            {
                entityParent.Children.Add(entity);
            }
        }

        public IEntity GetById(int id)
        {
            if (id < 0 || id >= this.Size)
            {
                return null;
            }

            return this.entities[this.Size - 1 - id];
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            var children = new List<IEntity>();

            if (parentId < 0 || parentId >= this.Size)
            {
                return children;
            }

            var parent = this.GetById(parentId);

            children.AddRange(parent.Children);

            return children;
        }
        public List<IEntity> GetAll()
            => new List<IEntity>(this.entities);

        public IRepository Copy()
        {
            var copy = new Data(this.entities);

            return copy;
        }

        public List<IEntity> GetAllByType(string type)
        {
            if (type != typeof(Invoice).Name
                && type != typeof(StoreClient).Name
                && type != typeof(User).Name)
            {
                throw new InvalidOperationException($"Invalid type: {type}");
            }

            var entitiesByType = new List<IEntity>();
            for (int i = 0; i < this.Size; i++)
            {
                var current = this.entities[i];

                if (current.GetType().Name == type)
                {
                    entitiesByType.Add(current);
                }
            }

            return entitiesByType;
        }

        public IEntity PeekMostRecent()
        {
            this.EnsureItsNotEmpty();

            return this.entities.GetFirst();
        }

        public IEntity DequeueMostRecent()
        {
            this.EnsureItsNotEmpty();

            return this.entities.RemoveFirst();
        }

        private void EnsureItsNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException("Operation on empty Data");
            }
        }
    }
}
