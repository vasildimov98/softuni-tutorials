namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models.Astronauts.Contracts;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly ICollection<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models
            => (IReadOnlyCollection<IAstronaut>)this.models;
        public void Add(IAstronaut model) => this.models.Add(model);
        public bool Remove(IAstronaut model) => this.models.Remove(model);
        public IAstronaut FindByName(string name)
            => this.Models
            .FirstOrDefault(a => a.Name == name);
    }
}
