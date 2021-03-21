namespace P03.VariationsWithoutRepetition
{
    using System;

    public class StartUp
    {
        private static string[] set;
        private static string[] variations;
        private static bool[] used;

        public static void Main()
        {
            set = Console.ReadLine().Split();
            var slots = int.Parse(Console.ReadLine());
            variations = new string[slots];
            used = new bool[set.Length];
            Variate(0);
        }

        private static void Variate(int variationIndex)
        {
            if (variationIndex == variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int setIndex = 0; setIndex < set.Length; setIndex++)
            {
                if (used[setIndex]) continue;

                variations[variationIndex] = set[setIndex];
                used[setIndex] = true;
                Variate(variationIndex + 1);
                used[setIndex] = false;
            }
        }
    }
}
