namespace P03.PeriodicTable
{
    using System;
    using System.Linq;

    using System.Collections.Generic;

    public class StartUp
    {
        private static SortedSet<string> sortedChemicalCompounds;
        public static void Main()
        {
            sortedChemicalCompounds = new SortedSet<string>();

            var numberOfCommands = int.Parse(Console.ReadLine());

            GetAllUniqueChemicalCompounds(numberOfCommands);

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(" ", sortedChemicalCompounds));
        }

        private static void GetAllUniqueChemicalCompounds(int numberOfCommands)
        {
            for (int i = 0; i < numberOfCommands; i++)
            {
                var compounds = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var compund in compounds)
                {
                    sortedChemicalCompounds.Add(compund);
                }
            }
        }
    }
}
