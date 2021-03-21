namespace P02.PermutationsWithRepetition
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private static string[] set;

        public static void Main()
        {
            set = Console.ReadLine().Split();
            Permute(0);
        }

        private static void Permute(int fromIndex)
        {
            if (fromIndex == set.Length)
            {
                Console.WriteLine(string.Join(" ", set));
                return;
            }

            Permute(fromIndex + 1);
            var swapped = new HashSet<string> { set[fromIndex] };
            for (int i = fromIndex + 1; i < set.Length; i++)
            {
                if (swapped.Contains(set[i])) continue;

                Swap(fromIndex, i);
                Permute(fromIndex + 1);
                Swap(fromIndex, i);

                swapped.Add(set[i]);
            }
        }

        private static void Swap(int firstIndex, int secondIndex)
        {
            var temp = set[firstIndex];
            set[firstIndex] = set[secondIndex];
            set[secondIndex] = temp;
        }
    }
}
