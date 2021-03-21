using P02.Raiding.Contracts;
using P02.Raiding.Models;
using System;
using System.Data;

namespace P02.Raiding.Factories
{
    public static class HeroFactory
    {
        public static IBaseHero CreateHero(string type, string name)
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
