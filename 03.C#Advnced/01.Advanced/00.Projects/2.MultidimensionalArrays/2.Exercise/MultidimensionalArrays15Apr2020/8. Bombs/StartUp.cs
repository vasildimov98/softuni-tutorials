using System;
using System.Linq;

namespace _8._Bombs
{
    class StartUp
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = rows;

            var matrix = ReadMatrix(rows, cols);

            var coordinates = Console
                .ReadLine()
                .Split();

            foreach (var coordinate in coordinates)
            {
                var data = coordinate
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var row = data[0];
                var col = data[1];

                var value = matrix[row, col];

                if (value <= 0)
                {
                    continue;
                }

                matrix[row, col] = 0;
                //down
                if (ValidateCell(row - 1, col, matrix))
                {
                    matrix[row - 1, col] -= value;
                }

                //up
                if (ValidateCell(row + 1, col, matrix))
                {
                    matrix[row + 1, col] -= value;
                }

                //right
                if (ValidateCell(row, col + 1, matrix))
                {
                    matrix[row, col + 1] -= value;
                }

                //right down
                if (ValidateCell(row - 1, col + 1, matrix))
                {
                    matrix[row - 1, col + 1] -= value;
                }

                //right up
                if (ValidateCell(row + 1, col + 1, matrix))
                {
                    matrix[row + 1, col + 1] -= value;
                }
                
                //left
                if (ValidateCell(row, col - 1, matrix))
                {
                    matrix[row, col - 1] -= value;
                }
                
                //left down
                if (ValidateCell(row - 1, col - 1, matrix))
                {
                    matrix[row - 1, col - 1] -= value;
                }
                
                //left up
                if (ValidateCell(row + 1, col - 1, matrix))
                {
                    matrix[row + 1, col - 1] -= value;
                }
            }

            var counterForAliveCells = 0;
            var sums = 0l;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        counterForAliveCells++;
                        sums += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {counterForAliveCells}");
            Console.WriteLine($"Sum: {sums}");
            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool ValidateCell(int row, int col, int[,] matrix)
        {
            if (row < 0 ||
                row >= matrix.GetLength(0) ||
                col < 0 ||
                col >= matrix.GetLength(1) ||
                matrix[row, col] <= 0)
            {
                return false;
            }

            return true;
        }
        static int[] ParseArray(params char[] splitSymbols)
        {
            return Console
                .ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        static int[,] ReadMatrix(int rows, int cols)
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
