namespace P04.CitiesByContinentAndCountry
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        private static Dictionary<string, Dictionary<string, List<string>>> continentsInfo;
        public static void Main()
        {
            continentsInfo = new Dictionary<string, Dictionary<string, List<string>>>();

            var numberOfCommands = int.Parse(Console.ReadLine());

            GetContinentsInfo(numberOfCommands);

            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var (continentName, countriesInfo) in continentsInfo)
            {
                Console.WriteLine($"{continentName}:");

                foreach (var (countryName, cities) in countriesInfo)
                {
                    Console.WriteLine($"  {countryName} -> {string.Join(", ", cities)}");
                }
            }
        }

        private static void GetContinentsInfo(int numberOfCommands)
        {
            for (int i = 0; i < numberOfCommands; i++)
            {
                var continentArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var continentName = continentArgs[0];
                var countryName = continentArgs[1];
                var cityName = continentArgs[2];

                if (!continentsInfo.ContainsKey(continentName))
                {
                    continentsInfo[continentName] = new Dictionary<string, List<string>>();
                }

                if (!continentsInfo[continentName].ContainsKey(countryName))
                {
                    continentsInfo[continentName][countryName] = new List<string>();
                }

                continentsInfo[continentName][countryName].Add(cityName);
            }
        }
    }
}
