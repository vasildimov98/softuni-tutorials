namespace P01.Two_Minutes_to_Midnight
{
    using System;
    class Program
    {
        private static long[,] table;
        static void Main()
        {
            var items = int.Parse(Console.ReadLine());
            var slots = int.Parse(Console.ReadLine());

            table = new long[items + 1, slots + 1];

            var numberOfWays = GetBinomalCoefficient(items, slots);

            Console.WriteLine(numberOfWays);
        }

        private static long GetBinomalCoefficient(int row, int col)
        {
            if (table[row, col] != 0) return table[row, col];

            if (col == 0 || col == row) return 1;

            var result = GetBinomalCoefficient(row - 1, col) + GetBinomalCoefficient(row - 1, col - 1);

            table[row, col] = result;

            return result;
        }
    }
}
