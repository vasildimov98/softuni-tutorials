namespace SantaWorkshop.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Dwarfs.Contracts;

    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly ICollection<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models
            => (IReadOnlyCollection<IDwarf>)this.models;

        public void Add(IDwarf model) => this.models.Add(model);
        public bool Remove(IDwarf model) => this.models.Remove(model);
        public IDwarf FindByName(string name)
            => this.models
            .FirstOrDefault(d => d.Name == name);
    }
}
