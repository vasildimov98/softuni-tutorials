namespace P02.Raiding.Core
{
    using System;

    using Contracts;
    using Factories;
    using IO.Contracts;
    using Repositories;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IRepository<IBaseHero> heroRepository;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroRepository = new HeroRepository();
        }

        public void Run()
        {
            var numberOfHeroesNeededForTheRaid = int.Parse(this.reader.ReadLine());

            this.GetAllHeroes(numberOfHeroesNeededForTheRaid);

            var bossPower = int.Parse(this.reader.ReadLine());

            PrintResult(bossPower);
        }

        private void PrintResult(int bossPower)
        {
            this.writer.WriteLine(this.heroRepository.ToString());

            var heroesPower = (this.heroRepository as HeroRepository).HerosPower();

            if (heroesPower >= bossPower)
            {
                this.writer.WriteLine("Victory!");
            }
            else
            {
                this.writer.WriteLine("Defeat...");
            }
        }

        private void GetAllHeroes(int n)
        {
            while (this.heroRepository.Count != n)
            {
                try
                {
                    var heroName = this.reader.ReadLine();
                    var heroType = this.reader.ReadLine();
                    var hero = HeroFactory.CreateHero(heroType, heroName);
                    heroRepository.Add(hero);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
            }
        }
    }
}
