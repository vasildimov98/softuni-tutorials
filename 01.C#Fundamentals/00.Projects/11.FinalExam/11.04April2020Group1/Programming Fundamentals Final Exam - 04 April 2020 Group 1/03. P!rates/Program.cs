using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            var population = new Dictionary<string, int>();
            var golds = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "Sail")
            {
                var data = command.Split("||");

                if (!population.ContainsKey(data[0]))
                {
                    population.Add(data[0], 0);
                    golds.Add(data[0], 0);
                }

                population[data[0]] += int.Parse(data[1]);
                golds[data[0]] += int.Parse(data[2]);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                var data = command.Split("=>");
                if (data[0] == "Plunder")
                {
                    population[data[1]] -= int.Parse(data[2]);
                    golds[data[1]] -= int.Parse(data[3]);
                    Console.WriteLine($"{data[1]} plundered! {data[3]} gold stolen, {data[2]} citizens killed.");
                    if (population[data[1]] <= 0 || golds[data[1]] <= 0)
                    {
                        population.Remove(data[1]);
                        golds.Remove(data[1]);

                        Console.WriteLine($"{data[1]} has been wiped off the map!");
                    }
                }
                else if (data[0] == "Prosper")
                {
                    int gold = int.Parse(data[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }
                    else
                    {
                        golds[data[1]] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {data[1]} now has {golds[data[1]]} gold.");
                    }
                }
            }

            if (population.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {population.Count} wealthy settlements to go to:");

                foreach (var city in golds
                    .OrderByDescending(g => g.Value)
                    .ThenBy(n => n.Key))
                {
                    Console.WriteLine($"{city.Key} -> Population: {population[city.Key]} citizens, Gold: {city.Value} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
