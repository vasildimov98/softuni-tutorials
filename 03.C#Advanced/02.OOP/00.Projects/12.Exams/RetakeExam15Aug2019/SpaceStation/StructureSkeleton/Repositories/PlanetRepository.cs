namespace SpaceStation.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Planets;

    class PlanetRepository : IRepository<IPlanet>
    {
        private readonly ICollection<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => (IReadOnlyCollection<IPlanet>)this.models;

        public void Add(IPlanet model) => this.models.Add(model);
        public bool Remove(IPlanet model) => this.models.Remove(model);
        public IPlanet FindByName(string name)
            => this.Models
            .FirstOrDefault(a => a.Name == name);
    }
}
