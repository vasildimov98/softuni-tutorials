namespace P05.GeneratingCombinations
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var slots = int.Parse(Console.ReadLine());

            var vector = new int[slots];
            GenAllCombination(numbers, vector);
        }

        private static void GenAllCombination(int[] numbers, int[] vector, int index = 0, int border = 0)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = border; i < numbers.Length; i++)
            {
                vector[index] = numbers[i];
                GenAllCombination(numbers, vector, index + 1, i + 1);
            }
        }
    }
}
