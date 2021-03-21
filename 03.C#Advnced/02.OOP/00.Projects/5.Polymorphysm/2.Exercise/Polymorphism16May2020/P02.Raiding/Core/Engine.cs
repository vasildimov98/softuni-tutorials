namespace P02.Raiding.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P02.Raiding.Conracts;
    using P02.Raiding.Core.Contracts;
    using P02.Raiding.Factories;
    using P02.Raiding.IO.Contracts;

    public class Engine : IEngine
    {
        private ICollection<IBaseHero> heros;
        private IReadable reader;
        private IWritable writer;

        private Engine()
        {
            this.heros = new List<IBaseHero>();
        }
        public Engine(IReadable readable, IWritable writable)
            : this()
        {
            this.reader = readable;
            this.writer = writable;
        }
        public void Run()
        {
            GetAllHeroes();

            var bossPower = int.Parse(reader.ReadLine());

            var herosPower = CastAllHerosAbility();

            PrintResult(bossPower, herosPower);
        }

        private void PrintResult(int bossPower, int herosPower)
        {
            if (herosPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }

        private int CastAllHerosAbility()
        {
            var power = 0;
            foreach (var hero in this.heros)
            {
                power += hero.Power;
                writer.WriteLine(hero.CastAbility());
            }

            return power;
        }

        private void GetAllHeroes()
        {
            var n = int.Parse(reader.ReadLine());

            while (heros.Count != n)
            {
                try
                {
                    CreateHero();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }
        }

        private void CreateHero()
        {
            var heroName = reader.ReadLine();
            var heroType = reader.ReadLine();

            this.heros.Add(HeroFactory.Create(heroName, heroType));
        }
    }
}
