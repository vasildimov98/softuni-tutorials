using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class StartUp
    {
        static void Main()
        {
            var input = ParseArray(',', ' ');

            var rows = input[0];
            var cols = input[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var data = ParseArray(' ');

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                var sum = 0;

                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }
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
