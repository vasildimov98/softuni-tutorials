namespace P04.IterativePermutationsWithoutRepetitions
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
                .Select(char.Parse)
                .ToArray();

            var setLength = set.Length;
            var permuteController = new int[setLength];

            var currIndex = 1;
            var sortedPermutation = new SortedDictionary<char, List<string>>
            {
                [set[0]] = new List<string> { string.Join(" ", set) }
            };
            while (currIndex < setLength)
            {
                if (currIndex > permuteController[currIndex])
                {
                    var swapIndex = (currIndex % 2 == 0) ? 0 : permuteController[currIndex];

                    Swap(set, swapIndex, currIndex);
                    permuteController[currIndex]++;
                    currIndex = 1;

                    if (!sortedPermutation.ContainsKey(set[0]))
                        sortedPermutation[set[0]] = new List<string>();
                    sortedPermutation[set[0]].Add(string.Join(" ", set));
                }
                else
                {
                    permuteController[currIndex] = 0;
                    currIndex++;
                }
            }

            foreach (var permutation in sortedPermutation)
                Console.WriteLine(string.Join(Environment.NewLine, permutation.Value));
        }

        private static void Swap(char[] set, int firstIndex, int secondIndex)
        {
            var temp = set[firstIndex];
            set[firstIndex] = set[secondIndex];
            set[secondIndex] = temp;
        }
    }
}
