namespace P08.CombinationsWithoutRepetition
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

            var vectorIndex = 0;
            var setIndex = 0;
            CombinationsWithoutRepetition(set, vector, setIndex, vectorIndex);
        }

        private static void CombinationsWithoutRepetition(string[] set,
            string[] vector,
            int setIndex,
            int vectorIndex)
        {
            if (vectorIndex >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = setIndex; i < set.Length; i++)
            {
                vector[vectorIndex] = set[i];
                CombinationsWithoutRepetition(set, vector, i + 1, vectorIndex + 1);
            }
        }
    }
}
