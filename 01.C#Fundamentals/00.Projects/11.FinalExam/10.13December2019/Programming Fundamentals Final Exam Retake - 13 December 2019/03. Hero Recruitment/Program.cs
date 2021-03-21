using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> spellsBook = new Dictionary<string, List<string>>();

            string command = "";
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];

                if (action == "Enroll")
                {
                    string heroName = data[1];

                    if (!spellsBook.ContainsKey(heroName))
                    {
                        spellsBook[heroName] = new List<string>();
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }
                else if (action == "Learn")
                {
                    string heroName = data[1];
                    string spellName = data[2];

                    if (!spellsBook.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (spellsBook[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                    }
                    else
                    {
                        spellsBook[heroName].Add(spellName);
                    }
                }
                else if (action == "Unlearn")
                {
                    string heroName = data[1];
                    string spellName = data[2];

                    if (!spellsBook.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (!spellsBook[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                    }
                    else
                    {
                        spellsBook[heroName].Remove(spellName);
                    }
                }
            }
            Console.WriteLine("Heroes:");
            foreach (var hero in spellsBook
                .OrderByDescending(a=>a.Value.Count())
                .ThenBy(a =>a.Key))
            {
                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
            }
        }
    }
}
