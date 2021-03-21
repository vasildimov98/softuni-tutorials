namespace P02.Socks
{
    using System;
    using System.Linq;

    class Program
    {
        private static int[,] table;
        private static int[] firstSocks;
        private static int[] secondSocks;
        static void Main()
        {
            firstSocks = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            secondSocks = Console
               .ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var rows = secondSocks.Length + 1;
            var cols = firstSocks.Length + 1;

            table = new int[rows, cols];

            FindLongestCommonSubsequence();

            Console.WriteLine(table[rows - 1, cols - 1]);
        }

        private static void FindLongestCommonSubsequence()
        {
            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (secondSocks[row - 1] == firstSocks[col - 1])
                        table[row, col] = table[row - 1, col - 1] + 1;
                    else table[row, col] = Math.Max(table[row, col - 1], table[row - 1, col]);
                }
            }
        }
    }
}
