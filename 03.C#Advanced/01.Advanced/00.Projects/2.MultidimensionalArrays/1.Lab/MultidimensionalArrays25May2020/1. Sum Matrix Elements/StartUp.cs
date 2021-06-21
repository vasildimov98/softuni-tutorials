using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = ParseArray(',', ' ');

            var rows = input[0];
            var cols = input[1];

            Console.WriteLine(rows);
            Console.WriteLine(cols);

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var data = ParseArray(',', ' ');

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            var sum = 0;
            foreach (var cel in matrix)
            {
                sum += cel;
            }

            Console.WriteLine(sum);
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
