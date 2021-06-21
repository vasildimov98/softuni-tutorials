namespace SantaWorkshop.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Models.Presents.Contracts;
    using Repositories.Contracts;

    public class PresentRepository : IRepository<IPresent>
    {
        private readonly ICollection<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models
            => (IReadOnlyCollection<IPresent>)this.models;

        public void Add(IPresent model) => this.models.Add(model);
        public bool Remove(IPresent model) => this.models.Remove(model);

        public IPresent FindByName(string name)
            => this.models
            .FirstOrDefault(p => p.Name == name);
    }
}
