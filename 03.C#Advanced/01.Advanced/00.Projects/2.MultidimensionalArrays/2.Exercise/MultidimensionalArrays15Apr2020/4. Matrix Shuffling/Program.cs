using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = ParseArrayInt(' ');

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = ReadMatrix(rows, cols);

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var data = command
                    .Split();

                if (data[0] != "swap" || data.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var row1 = int.Parse(data[1]);
                var col1 = int.Parse(data[2]);
                var row2 = int.Parse(data[3]);
                var col2 = int.Parse(data[4]);

                var isValid = ValidIndex(matrix, row1, row2, col1, col2);

                if (!isValid)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var temp = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = temp;

                PrintMatrix(matrix, rows, cols);
            }
        }

        static void PrintMatrix(string[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        static bool ValidIndex(string[,] matrix, int row1, int row2, int col1, int col2)
        {
            if (row1 < 0 || row2 < 0 || col1 < 0 || col2 < 0)
            {
                return false;
            }

            if (row1 >= matrix.GetLength(0) || row2 >= matrix.GetLength(0) || col1 >= matrix.GetLength(1)|| col2 >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
        static string[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var data = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            return matrix;
        }

        static int[] ParseArrayInt(params char[] splitSymbols)
        {
            return Console
                .ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
