namespace P02.Raiding.Repositories
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository : IRepository<IBaseHero>
    {
        private readonly ICollection<IBaseHero> models;

        public HeroRepository()
        {
            this.models = new List<IBaseHero>();
        }

        public int Count => this.models.Count;

        public void Add(IBaseHero model)
            => this.models.Add(model);
        public int HerosPower()
            => this.models.Sum(h => h.Power);
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var hero in this.models)
            {
                sb.AppendLine(hero.CastAbility());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
