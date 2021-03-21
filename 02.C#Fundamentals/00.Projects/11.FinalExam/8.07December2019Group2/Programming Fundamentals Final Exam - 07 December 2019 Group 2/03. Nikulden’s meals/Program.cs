using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();
            int countOfUnlikeMeals = 0;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] data = command
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];

                if (action == "Like")
                {
                    string guest = data[1];
                    if (!guests.ContainsKey(guest))
                    {
                        guests[guest] = new List<string>();
                    }

                    string meal = data[2];
                    if (!guests[guest].Contains(meal))
                    {
                        guests[guest].Add(meal);
                    }
                }
                else if (action == "Unlike")
                {
                    string guest = data[1];
                    string meal = data[2];
                    if (guests.ContainsKey(guest) && guests[guest].Contains(meal))
                    {
                        guests[guest].Remove(meal);
                        countOfUnlikeMeals++;
                        Console.WriteLine($"{guest} doesn't like the {meal}.");
                    }
                    else if (!guests.ContainsKey(guest))
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                    else if (!guests[guest].Contains(meal))
                    {
                        Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                    }
                }
            }

            var sorted = guests
                .OrderByDescending(a => a.Value.Count())
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var guest in sorted)
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");
            }

            Console.WriteLine($"Unliked meals: {countOfUnlikeMeals}");
        }
    }
}
