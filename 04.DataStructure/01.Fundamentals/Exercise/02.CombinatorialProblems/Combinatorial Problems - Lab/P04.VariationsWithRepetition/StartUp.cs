namespace P04.VariationsWithRepetition
{
    using System;

    public class StartUp
    {
        private static string[] set;
        private static string[] variations;
        public static void Main()
        {
            set = Console.ReadLine().Split();
            var slots = int.Parse(Console.ReadLine());
            variations = new string[slots];
            VariateWithRepitation(0);
        }

        private static void VariateWithRepitation(int variationIndex)
        {
            if (variationIndex == variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int setIndex = 0; setIndex < set.Length; setIndex++)
            {
                variations[variationIndex] = set[setIndex];
                VariateWithRepitation(variationIndex + 1);
            }
        }
    }
}
