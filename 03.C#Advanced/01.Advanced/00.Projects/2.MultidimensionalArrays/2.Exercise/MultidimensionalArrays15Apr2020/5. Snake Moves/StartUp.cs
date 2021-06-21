using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dimensions = ParseArrayInt(' ');
            var snake = Console.ReadLine();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new string[rows, cols];

            var counter = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row % 2 == 0)
                    {
                        matrix[row, col] = snake[counter++].ToString();
                    }
                    else
                    {
                        matrix[row, cols - 1 - col] = snake[counter++].ToString();
                    }

                    if (counter == snake.Length)
                    {
                        counter = 0;
                    }
                }
            }

            PrintMatrix(matrix, rows, cols);
        }


        static void PrintMatrix(string[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
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
