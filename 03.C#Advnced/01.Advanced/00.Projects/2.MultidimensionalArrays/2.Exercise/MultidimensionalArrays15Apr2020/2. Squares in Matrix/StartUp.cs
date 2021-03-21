using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dimensions = ParseArrayToInt(' ');

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = ReadCharMatrix(rows, cols);
            var counter = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }

        static char[,] ReadCharMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var data = ParseArrayToChar(' ');

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            return matrix;
        }

        static char[] ParseArrayToChar(params char[] splitSymbol)
        {
            return Console
                .ReadLine()
                .Split(splitSymbol, StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();
        }

        static int[] ParseArrayToInt(params char[] splitSymbol)
        {
            return Console
                .ReadLine()
                .Split(splitSymbol, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
