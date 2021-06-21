namespace ViceCity.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Guns.Contracts;
    public class GunRepository : IRepository<IGun>
    {
        private readonly ICollection<IGun> models;

        public GunRepository()
        {
            this.models = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
            => (IReadOnlyCollection<IGun>)this.models;

        public void Add(IGun model)
        {
            if (!this.Models.Any(m => m.Name == model.Name))
            {
                this.models.Add(model);
            }
        }
        public bool Remove(IGun model)
            => this.models.Remove(model);
        public IGun Find(string name)
            => this.Models
            .FirstOrDefault(m => m.Name == name);
    }
}
