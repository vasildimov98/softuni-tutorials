using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = ParseArrayToInt(' ');

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = ReadMatrix(rows, cols);

            var maxSum = 0l;
            var maxRowIndex = 0;
            var maxColIndex = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var firsRowSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    var secondRowSum = matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    var thirdRowSum = matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    var currentSum = firsRowSum + secondRowSum + thirdRowSum;

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRowIndex = row;
                        maxColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = maxRowIndex; row < maxRowIndex + 3; row++)
            {
                for (int col = maxColIndex; col < maxColIndex + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        static int[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var data = ParseArrayToInt(' ');

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            return matrix;
        }

        static int[] ParseArrayToInt(params char[] splitSymbols)
        {
            return Console
                .ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
