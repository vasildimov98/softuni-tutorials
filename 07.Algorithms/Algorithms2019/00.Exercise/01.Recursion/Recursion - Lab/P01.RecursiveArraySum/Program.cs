namespace P01.RecursiveArraySum
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

            var recsSum = CalcSumRecurs(numbers);
            Console.WriteLine(recsSum);
        }

        private static int CalcSumRecurs(int[] numbers, int index = 0)
        {
            if (index == numbers.Length - 1) return numbers[index];

            Console.WriteLine($"Pre-action {index}");

            var sum = numbers[index] + CalcSumRecurs(numbers, index += 1);

            Console.WriteLine($"Post-action {index}");

            return sum;
        }
    }
}
