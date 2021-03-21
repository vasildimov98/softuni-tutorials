using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var matrix = new int[rows, rows];
            ReadMatrix(matrix, rows);

            var sum = 0;
            for (int i = 0; i < rows; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }


        private static int[,] ReadMatrix(int[,] matrix, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                var data = ParseArray(' ');

                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            return matrix;
        }
        private static int[] ParseArray(params char[] splitSymbols)
        {
            return Console
                .ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
