namespace P05.VariationsWithRepetition
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

            var slots = int.Parse(Console.ReadLine());
            var vector = new string[slots];

            VariationsWithRepetition(set, vector, 0);
        }

        private static void VariationsWithRepetition(string[] set, string[] vector, int vectorIndex)
        {
            if (vectorIndex == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int setIndex = 0; setIndex < set.Length; setIndex++)
            {
                vector[vectorIndex] = set[setIndex];
                VariationsWithRepetition(set, vector, vectorIndex + 1);
            }
        }
    }
}
