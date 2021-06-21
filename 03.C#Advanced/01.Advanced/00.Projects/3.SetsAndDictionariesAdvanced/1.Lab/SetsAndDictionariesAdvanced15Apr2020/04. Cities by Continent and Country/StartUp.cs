using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_by_Continent_and_Country
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                var data = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var continents = data[0];
                var country = data[1];
                var city = data[2];

                if (!dict.ContainsKey(continents))
                {
                    dict[continents] = new Dictionary<string, List<string>>();
                }

                if (!dict[continents].ContainsKey(country))
                {
                    dict[continents][country] = new List<string>();
                }

                dict[continents][country].Add(city);
            }

            PrintDict(dict);
        }

        static void PrintDict(Dictionary<string, Dictionary<string, List<string>>> dict)
        {
            foreach (var (continent, countries) in dict)
            {
                Console.WriteLine($"{continent}:");

                foreach (var (country, cities) in countries)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
