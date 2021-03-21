namespace P02.PermutationsWithRepetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var set = Console
                .ReadLine()
                .Split()
                .ToArray();

            PermutationsWithRepetition(set, 0);
        }

        private static void PermutationsWithRepetition(string[] set, int currIndex)
        {
            if (currIndex == set.Length)
            {
                Console.WriteLine(string.Join(" ", set));
                return;
            }

            var swapped = new HashSet<string>();
            for (int i = currIndex; i < set.Length; i++)
            {
                if (swapped.Contains(set[i])) continue;
                swapped.Add(set[i]);

                Swap(set, currIndex, i);
                PermutationsWithRepetition(set, currIndex + 1);
                Swap(set, currIndex, i);
            }
        }

        private static void Swap(string[] set, int firstIndex, int secondIndex)
        {
            var temp = set[firstIndex];
            set[firstIndex] = set[secondIndex];
            set[secondIndex] = temp;
        }
    }
}
