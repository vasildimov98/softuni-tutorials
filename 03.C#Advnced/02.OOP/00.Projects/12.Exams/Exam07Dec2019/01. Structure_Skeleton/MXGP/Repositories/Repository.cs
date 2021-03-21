namespace MXGP.Repositories
{
    using System.Collections.Generic;

    using Contracts;

    public abstract class Repository<T> : IRepository<T>
    {
        private readonly ICollection<T> models;
        public Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models
            => (IReadOnlyCollection<T>)this.models;

        public void Add(T model) => this.models.Add(model);
        public bool Remove(T model) => this.models.Remove(model);
        public abstract T GetByName(string name);
        public IReadOnlyCollection<T> GetAll()
            => this.Models;
    }
}
