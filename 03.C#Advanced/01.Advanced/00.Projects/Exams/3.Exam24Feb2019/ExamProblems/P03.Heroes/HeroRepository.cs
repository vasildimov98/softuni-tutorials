using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            var heroToRemove = this.data
                .FirstOrDefault(h => h.Name == name);

            if (heroToRemove != null)
            {
                this.data.Remove(heroToRemove);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.data
                .OrderByDescending(h => h.Item.Strength)
                .FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.data
                .OrderByDescending(h => h.Item.Ability)
                .FirstOrDefault();
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            return this.data
                .OrderByDescending(h => h.Item.Intelligence)
                .FirstOrDefault();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var hero in this.data)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
