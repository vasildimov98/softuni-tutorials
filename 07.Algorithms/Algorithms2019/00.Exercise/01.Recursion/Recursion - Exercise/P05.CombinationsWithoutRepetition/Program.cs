namespace P05.CombinationsWithoutRepetition
{
    using System;
    class Program
    {
        static void Main()
        {
            var numbers = int.Parse(Console.ReadLine());
            var slots = int.Parse(Console.ReadLine());
            var vector = new int[slots];

            var startIndex = 0;
            var firstNumber = 1;
            GenerateAllCombinationWithoutRepetition(vector, startIndex, firstNumber, numbers);
        }

        private static void GenerateAllCombinationWithoutRepetition(int[] vector,
            int currIndex,
            int fromNumber,
            int toNumber)
        {
            if (currIndex == vector.Length)
            {
                PrintCombination(vector);
                return;
            }

            for (int currNumber = fromNumber; currNumber <= toNumber; currNumber++)
            {
                vector[currIndex] = currNumber;
                GenerateAllCombinationWithoutRepetition(vector, currIndex + 1, currNumber + 1, toNumber);
            }
        }

        private static void PrintCombination(int[] vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
    }
}
