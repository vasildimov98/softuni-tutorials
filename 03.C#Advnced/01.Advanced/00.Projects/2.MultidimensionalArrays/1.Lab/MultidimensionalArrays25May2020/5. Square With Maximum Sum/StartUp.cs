using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = ParseArray(',', ' ');

            var rows = input[0];
            var cols = input[1];
            var matrix = ReadMatrix(rows, cols);

            var maxSum = int.MinValue;
            var maxRow = 0;
            var maxCol = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                   var sum = matrix[row, col]
                        + matrix[row, col + 1]
                        + matrix[row + 1, col]
                        + matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
            Console.WriteLine(maxSum);
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var data = ParseArray(',', ' ');

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            return matrix;
        }
        private static int[] ParseArray(params char[] splitSymbol)
        {
            return Console
                .ReadLine()
                .Split(splitSymbol, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
