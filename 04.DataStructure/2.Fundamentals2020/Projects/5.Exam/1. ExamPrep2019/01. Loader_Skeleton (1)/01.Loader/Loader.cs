namespace _01.Loader
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Models;
    using Interfaces;

    public class Loader : IBuffer
    {
        private readonly List<IEntity> entities;

        public Loader()
        {
            this.entities = new List<IEntity>();
        }

        public int EntitiesCount => this.entities.Count;

        public void Add(IEntity entity)
            => this.entities
            .Add(entity);

        public IEntity Extract(int id)
        {
            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var current = this.entities[i];

                if (current.Id == id)
                {
                    this.entities.RemoveAt(i);

                    return current;
                }
            }

            return null;
        }

        public IEntity Find(IEntity entity)
        {
            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var current = this.entities[i];

                if (current == entity)
                {
                    return current;
                }
            }

            return null;
        }

        public bool Contains(IEntity entity)
        {
            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var current = this.entities[i];

                if (current == entity)
                {
                    return true;
                }
            }

            return false;
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            var indexOfOldEntity = this.entities.IndexOf(oldEntity);

            this.ValidateIndex(indexOfOldEntity);

            this.entities[indexOfOldEntity] = newEntity;
        }

        public void Swap(IEntity first, IEntity second)
        {
            var indexOfFirst = this.entities.IndexOf(first);
            this.ValidateIndex(indexOfFirst);
            var indexOfSecond = this.entities.IndexOf(second);
            this.ValidateIndex(indexOfSecond);

            var temp = this.entities[indexOfFirst];
            this.entities[indexOfFirst] = this.entities[indexOfSecond];
            this.entities[indexOfSecond] = temp;
        }

        public void Clear()
            => this.entities
            .Clear();

        public IEntity[] ToArray()
            => this.entities
            .ToArray();

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            var lowerBoundInt = (int)lowerBound;
            var upperBoundInt = (int)upperBound;

            var result = new List<IEntity>();

            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var current = this.entities[i];

                if (current.Status >= lowerBound
                    && upperBound >= current.Status)
                {
                    result.Add(current);
                }
            }

            return result;
        }

        public List<IEntity> GetAll()
            => new List<IEntity>(this.entities);

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {
            for (int i = 0; i < this.EntitiesCount; i++)
            {
                var current = this.entities[i];

                if (current.Status == oldStatus)
                {
                    current.Status = newStatus;
                }
            }
        }

        public void RemoveSold()
            => this.entities
            .RemoveAll(e => e.Status == BaseEntityStatus.Sold);

        public IEnumerator<IEntity> GetEnumerator()
            => this.entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void ValidateIndex(int indexOfOldEntity)
        {
            if (indexOfOldEntity == -1)
            {
                throw new InvalidOperationException("Entity not found");
            }
        }
    }
}
