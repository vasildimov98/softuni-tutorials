namespace P03.HeroesOfCodeAndLogicVII
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var heroes = new Dictionary<string, int[]>();

            PickAllTheHeroesForTheGameParty(n, heroes);

            ProceedCommand(heroes);

            PrintAliveHeroes(heroes);
        }

        private static void PrintAliveHeroes(Dictionary<string, int[]> heroes)
        {
            var sortedHeroes = heroes
                            .OrderByDescending(h => h.Value[0])
                            .ThenBy(h => h.Key)
                            .ToList();

            foreach (var (name, heroInfo) in sortedHeroes)
            {
                Console.WriteLine(name);
                Console.WriteLine($" HP: {heroInfo[0]}");
                Console.WriteLine($" MP: {heroInfo[1]}");
            }
        }

        private static void ProceedCommand(Dictionary<string, int[]> heroes)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var args = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = args[0];

                if (action == "CastSpell")
                {
                    TryCastSpell(heroes, args);
                }
                else if (action == "TakeDamage")
                {
                    TakeDamage(heroes, args);
                }
                else if (action == "Recharge")
                {
                    RecharchMP(heroes, args);
                }
                else
                {
                    Heal(heroes, args);
                }
            }
        }

        private static void Heal(Dictionary<string, int[]> heroes, string[] args)
        {
            var heroName = args[1];
            var amount = int.Parse(args[2]);

            var hero = heroes[heroName];

            var maxHP = 100;
            var heal = hero[0];
            int recharedHP;

            if (heal + amount > maxHP)
            {
                recharedHP = maxHP - heal;

                hero[0] = maxHP;
            }
            else
            {
                recharedHP = amount;

                hero[0] += amount;
            }

            Console.WriteLine($"{heroName} healed for {recharedHP} HP!");
        }

        private static void RecharchMP(Dictionary<string, int[]> heroes, string[] args)
        {
            var heroName = args[1];
            var amount = int.Parse(args[2]);

            var hero = heroes[heroName];

            var maxMP = 200;
            int recharedMP;
            if (hero[1] + amount > maxMP)
            {
                recharedMP = maxMP - hero[1];

                hero[1] = maxMP;
            }
            else
            {
                recharedMP = amount;

                hero[1] += amount;
            }

            Console.WriteLine($"{heroName} recharged for {recharedMP} MP!");
        }

        private static void TakeDamage(Dictionary<string, int[]> heroes, string[] args)
        {
            var heroName = args[1];
            var damage = int.Parse(args[2]);
            var attacker = args[3];

            var hero = heroes[heroName];

            hero[0] -= damage;

            if (hero[0] > 0)
            {
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {hero[0]} HP left!");
            }
            else
            {
                heroes.Remove(heroName);

                Console.WriteLine($"{heroName} has been killed by {attacker}!");
            }
        }

        private static void TryCastSpell(Dictionary<string, int[]> heroes, string[] args)
        {
            var name = args[1];
            var mpNeeded = int.Parse(args[2]);
            var spellName = args[3];

            var hero = heroes[name];

            if (hero[1] >= mpNeeded)
            {
                hero[1] -= mpNeeded;

                Console.WriteLine($"{name} has successfully cast {spellName} and now has {hero[1]} MP!");
            }
            else
            {
                Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
            }
        }

        private static void PickAllTheHeroesForTheGameParty(int n, Dictionary<string, int[]> heroes)
        {
            for (int i = 0; i < n; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = args[0];
                var hp = int.Parse(args[1]);
                var mp = int.Parse(args[2]);

                if (!heroes.ContainsKey(name))
                {
                    heroes[name] = new int[2] { hp, mp };
                }
            }
        }
    }
}
