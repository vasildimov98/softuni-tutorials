using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class StartUp
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = rows;

            var matrix = ReadMatrix(rows, cols);

            var primaryDiagonal = 0;
            var secondaryDiagonal = 0;

            for (int i = 0; i < rows; i++)
            {
                primaryDiagonal += matrix[i, i];
                secondaryDiagonal += matrix[i, cols - 1 - i];
            }

            var diff = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(diff);
        }

        static int[] ParseArray(params char[] splitSymbol)
        {
            return Console
                .ReadLine()
                .Split(splitSymbol, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var data = ParseArray(' ');

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            return matrix;
        }
    }
}
