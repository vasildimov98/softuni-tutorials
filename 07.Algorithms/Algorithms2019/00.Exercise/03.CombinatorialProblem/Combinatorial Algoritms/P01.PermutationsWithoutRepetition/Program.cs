namespace P01.PermutationsWithoutRepetition
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var set = Console
                .ReadLine()
                .Split()
                .ToArray();

            Permute(set, 0);
        }

        private static void Permute(string[] set, int currIndex)
        {
            if (currIndex == set.Length)
            {
                Console.WriteLine(string.Join(" ", set));
                return;
            }

            Permute(set, currIndex + 1);

            for (int i = currIndex + 1; i < set.Length; i++)
            {
                Swap(set, currIndex, i);
                Permute(set, currIndex + 1);
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
