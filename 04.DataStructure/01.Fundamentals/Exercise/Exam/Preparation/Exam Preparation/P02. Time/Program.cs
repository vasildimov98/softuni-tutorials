namespace P02._Time
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var firstTimeline = Console
                .ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var secondTimeline = Console
                .ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var table = new int[secondTimeline.Length + 1, firstTimeline.Length + 1];

            FindLongestCommonSubSequence(table, firstTimeline, secondTimeline);
            //PrintMatirix(table);
            var sequence = BacktrackSequence(table, firstTimeline, secondTimeline);
            Console.WriteLine(string.Join(" ", sequence));
            Console.WriteLine(sequence.Count);
        }

        private static Stack<int> BacktrackSequence(int[,] table,
            int[] firstTimeline,
            int[] secondTimeline)
        {
            var sequence = new Stack<int>();

            var row = secondTimeline.Length;
            var col = firstTimeline.Length;

            while (row > 0 && col > 0)
            {
                if (secondTimeline[row - 1] == firstTimeline[col - 1])
                {
                    row--;
                    col--;
                    sequence.Push(secondTimeline[row]);
                }
                else if (table[row, col - 1] <= table[row - 1, col]) row--;
                else col--;
            }

            return sequence;
        }

        private static void PrintMatirix(int[,] matrix)
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

        private static void FindLongestCommonSubSequence(int[,] table,
            int[] firstTimeline,
            int[] secondTimeline)
        {
            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    if (secondTimeline[row - 1] == firstTimeline[col - 1])
                        table[row, col] = table[row - 1, col - 1] + 1;
                    else table[row, col] = Math.Max(table[row, col - 1], table[row - 1, col]);
                }
            }
        }
    }
}
