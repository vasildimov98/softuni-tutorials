namespace P01.BinomialCoefficients
{
    using System;
    class Program
    {
        private static long[,] cashe;
        static void Main()
        {
            var numbers = int.Parse(Console.ReadLine());
            var slots = int.Parse(Console.ReadLine());

            cashe = new long[numbers + 1, slots + 1];

            var coefficent = GetBinomicalCoefficients(numbers, slots);

            Console.WriteLine(coefficent);
        }

        private static long GetBinomicalCoefficients(int row, int col)
        {
            if (cashe[row, col] != 0) return cashe[row, col];

            if (col == 0 || col == row) return 1;

            var result = GetBinomicalCoefficients(row - 1, col - 1) + GetBinomicalCoefficients(row - 1, col);

            cashe[row, col] = result;

            return result;
        }
    }
}
