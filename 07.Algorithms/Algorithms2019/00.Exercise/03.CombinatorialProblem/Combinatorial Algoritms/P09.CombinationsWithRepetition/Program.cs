namespace P09.CombinationsWithRepetition
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

            var startIndex = 0;
            var vectorIndex = 0;
            CombinationsWithRepetition(set, vector, startIndex, vectorIndex);
        }

        private static void CombinationsWithRepetition(string[] set,
            string[] vector,
            int startIndex,
            int vectorIndex)
        {
            if (vectorIndex == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int fromIndex = startIndex; fromIndex < set.Length; fromIndex++)
            {
                vector[vectorIndex] = set[fromIndex];
                CombinationsWithRepetition(set, vector, fromIndex, vectorIndex + 1);
            }
        }
    }
}
