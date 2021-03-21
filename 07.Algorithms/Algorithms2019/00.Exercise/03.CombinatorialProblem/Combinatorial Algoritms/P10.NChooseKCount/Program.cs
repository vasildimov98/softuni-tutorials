namespace P10.NChooseKCount
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static readonly Dictionary<string, long> memo = new Dictionary<string, long>();
        static void Main()
        {
            var numbers = int.Parse(Console.ReadLine());
            var slots = int.Parse(Console.ReadLine());

            var coefficients = BinomialCoefficient(numbers, slots);

            Console.WriteLine(coefficients);
        }

        private static long BinomialCoefficient(int row, int col)
        {
            if (col == 0 || col == row) return 1;
            var id = $"{row} {col}";

            if (memo.ContainsKey(id)) return memo[id];

           var coefficients = BinomialCoefficient(row - 1, col - 1) + BinomialCoefficient(row - 1, col);

            memo[id] = coefficients;

            return coefficients;
        }
    }
}
