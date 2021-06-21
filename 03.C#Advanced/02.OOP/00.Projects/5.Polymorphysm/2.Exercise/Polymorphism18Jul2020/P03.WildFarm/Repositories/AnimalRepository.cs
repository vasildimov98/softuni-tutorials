namespace P03.WildFarm.Repositories
{
    using System.Text;
    using System.Collections.Generic;

    using Contracts;

    public class AnimalRepository : IRepository<IAnimal>
    {
        private readonly ICollection<IAnimal> models;

        public AnimalRepository()
        {
            this.models = new List<IAnimal>();
        }

        public IReadOnlyCollection<IAnimal> Models
            => (IReadOnlyCollection<IAnimal>)this.models;

        public void Add(IAnimal animal)
        {
            if (animal != null)
            {
                this.models.Add(animal);
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var animal in this.Models)
            {
                sb.AppendLine(animal.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
