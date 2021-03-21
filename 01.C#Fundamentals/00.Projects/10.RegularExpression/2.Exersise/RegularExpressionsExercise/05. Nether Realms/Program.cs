using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string split = @"[^,\s]+";
            string healthRegEx = @"[^0-9+\-*\/.]";
            string basicDamageRegEx = @"[+-]?[0-9]*\.?[0-9]+";
            string operators = @"[*\/]";
            string[] monsterData = Regex
                .Matches(input, split)
                .Cast<Match>()
                .Select(a => a.Value)
                .ToArray();

            SortedDictionary<string, string> demonsBook = new SortedDictionary<string, string>();
            foreach (var name in monsterData)
            {
                var matchesHealth = Regex.Matches(name, healthRegEx);
                double health = 0;
                foreach (Match match1 in matchesHealth)
                {
                    health += char.Parse(match1.Value);
                }

                var matchesDamage = Regex.Matches(name, basicDamageRegEx);
                double damage = 0;

                foreach (Match match2 in matchesDamage)
                {
                    damage += double.Parse(match2.Value);
                }

                var operatorsMatches = Regex.Matches(name, operators);
                foreach (Match opert in operatorsMatches)
                {
                    if (opert.Value == "*")
                    {
                        damage *= 2;
                    }
                    else if (opert.Value == "/")
                    {
                        damage /= 2;
                    }
                }

                string result = health + ":" + damage;

                demonsBook.Add(name, result);
            }

            foreach (var demon in demonsBook)
            {
                double[] info = demon.Value
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                Console.WriteLine($"{demon.Key} - {info[0]} health, {info[1]:F2} damage");
            }
        }
    }
}
