namespace P06.ConnectingCables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var permutationOfCables = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var orderedCables = new int[permutationOfCables.Length];
            for (int i = 0; i < orderedCables.Length; i++)
                orderedCables[i] = i + 1;

            var table = new int[orderedCables.Length + 1, orderedCables.Length + 1];
            FillTable(permutationOfCables, orderedCables, table);

            PrintMatrix(table);
            PrintResult(table, permutationOfCables, orderedCables);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintResult(int[,] table, int[] permutationOfCables, int[] orderedCables)
        {
            var countOfPairs = table[orderedCables.Length, orderedCables.Length];

            Console.WriteLine($"Maximum pairs connected: {countOfPairs}");

            var row = permutationOfCables.Length;
            var col = permutationOfCables.Length;

            var cables = new Stack<int>(); 
            while (row > 0 && col > 0)
            {
                if (orderedCables[row - 1] == permutationOfCables[col - 1])
                {
                    cables.Push(orderedCables[row - 1]);
                    row--;
                    col--;
                }
                else if (table[row, col - 1] > table[row - 1, col]) col--;
                else row--;
            }

            Console.WriteLine(string.Join(" ", cables));
        }

        private static void FillTable(int[] permutationOfCables, int[] orderedCables, int[,] table)
        {
            for (int row = 1; row < table.GetLength(0); row++)
                for (int col = 1; col < table.GetLength(1); col++)
                    if (orderedCables[row - 1] == permutationOfCables[col - 1])
                        table[row, col] = table[row - 1, col - 1] + 1;
                    else table[row, col] = Math.Max(table[row, col - 1], table[row - 1, col]);
        }
    }
}
