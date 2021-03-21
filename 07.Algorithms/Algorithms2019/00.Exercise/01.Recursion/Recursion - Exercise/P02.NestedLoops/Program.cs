namespace P02.NestedLoops
{
    using System;
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var vector = new int[number];

            GenerateAllVariation(vector, 0);
        }

        private static void GenerateAllVariation(int[] vector, int startIndex)
        {
            if (startIndex >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int number = 1; number <= vector.Length; number++)
            {
                vector[startIndex] = number;
                GenerateAllVariation(vector, startIndex + 1);
            }
        }
    }
}
