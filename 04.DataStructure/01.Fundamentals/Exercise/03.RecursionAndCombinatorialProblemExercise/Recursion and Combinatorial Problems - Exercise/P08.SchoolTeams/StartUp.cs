namespace P08.SchoolTeams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");

            var girlsComb = new string[3];
            var girlsCombinations = new List<string>();

            GenerateCombination(girls, girlsComb, girlsCombinations);

            var boysComb = new string[2];
            var boysCombinations = new List<string>();

            GenerateCombination(boys, boysComb, boysCombinations);

            foreach (var girlsString in girlsCombinations)
            {
                foreach (var boysString in boysCombinations)
                {
                    Console.WriteLine($"{girlsString}, {boysString}");
                }
            }
        }

        private static void GenerateCombination(string[] set,
            string[] combination,
            List<string> combinations,
            int combinationIndex = 0,
            int setIndex = 0)
        {
            if (combinationIndex == combination.Length)
            {
                combinations.Add(string.Join(", ", combination));
                return;
            }

            for (int currSetIndex = setIndex; currSetIndex < set.Length; currSetIndex++)
            {
                combination[combinationIndex] = set[currSetIndex];
                GenerateCombination(set, combination, combinations, combinationIndex + 1, currSetIndex + 1);
            }
        }
    }
}
