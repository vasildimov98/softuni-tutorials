namespace P03.CombinationsWithRepetition
{
    using System;
    class Program
    {
        static void Main()
        {
            var numbers = int.Parse(Console.ReadLine());
            var slots = int.Parse(Console.ReadLine());

            var vector = new int[slots];
            GenerateCombinationWithRepetiotion(vector, numbers);
        }

        private static void GenerateCombinationWithRepetiotion(int[] vector, int numbers, int firstNumb = 1, int currIndex = 0)
        {
            if (currIndex == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int number = firstNumb; number <= numbers; number++)
            {
                vector[currIndex] = number;
                GenerateCombinationWithRepetiotion(vector, numbers, number, currIndex + 1);
            }
        }
    }
}
