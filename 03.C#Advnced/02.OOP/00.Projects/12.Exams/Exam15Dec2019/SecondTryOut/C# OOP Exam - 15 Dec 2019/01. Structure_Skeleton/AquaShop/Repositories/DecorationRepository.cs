namespace AquaShop.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models.Decorations.Contracts;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models 
            => (IReadOnlyCollection<IDecoration>)this.models;

        public void Add(IDecoration model)
            => this.models.Add(model);

        public bool Remove(IDecoration model)
            => this.models.Remove(model);

        public IDecoration FindByType(string type)
            => this.Models
            .FirstOrDefault(m => m.GetType().Name == type);
    }
}
