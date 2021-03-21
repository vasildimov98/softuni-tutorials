namespace P01.PermutationsWithoutRepetition
{
    using System;

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
            for (int i = fromIndex + 1; i < set.Length; i++)
            {
                Swap(fromIndex, i);
                Permute(fromIndex + 1);
                Swap(fromIndex, i);
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
