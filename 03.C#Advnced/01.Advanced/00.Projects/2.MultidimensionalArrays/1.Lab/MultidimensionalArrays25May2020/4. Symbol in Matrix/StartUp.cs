using System;

namespace _4._Symbol_in_Matrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var rows = n;
            var cols = n;

            var matrix = ReadMatrix(rows, cols);

            var symbol = Console.ReadLine();

            var flag = false;
            var symbolRow = 0;
            var symbolCol = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        flag = true;
                        symbolRow = row;
                        symbolCol = col;
                        break;
                    }
                }

                if (flag)
                {
                    break;
                }
            }

            if (flag)
            {
                Console.WriteLine($"({symbolRow}, {symbolCol})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }

        private static string[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var data = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col].ToString();
                }
            }
            return matrix;
        }
    }
}
