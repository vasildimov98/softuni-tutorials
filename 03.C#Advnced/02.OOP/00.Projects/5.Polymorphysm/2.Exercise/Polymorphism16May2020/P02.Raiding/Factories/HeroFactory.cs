namespace P02.Raiding.Factories
{
    using System;

    using P02.Raiding.Modules;
    using P02.Raiding.Conracts;
    public static class HeroFactory
    {
        public static IBaseHero Create(string name, string type)
        {
            if (type == "Druid")
            {
                return new Druid(name);
            }
            else if (type == "Paladin")
            {
                return new Paladin(name);
            }
            else if (type == "Rogue")
            {
                return new Rogue(name);
            }
            else if (type == "Warrior")
            {
                return new Warrior(name);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
