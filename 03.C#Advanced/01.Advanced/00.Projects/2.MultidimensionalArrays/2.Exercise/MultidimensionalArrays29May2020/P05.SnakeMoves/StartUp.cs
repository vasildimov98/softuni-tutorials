namespace P05.SnakeMoves
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static char[,] matrix;
        private static int count;
        public static void Main()
        {
            var dimensions = Console
                 .ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];
            matrix = new char[rows, cols];
            var snake = Console.ReadLine();
            GetMatrixFilled(rows, cols, snake);
            PrintMatrix(rows, cols);
        }

        private static void PrintMatrix(int rows, int cols)
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

        private static void GetMatrixFilled(int rows, int cols, string snake)
        {
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    AddElemntsStraightForwads(cols, snake, row);
                }
                else
                {
                    AddElemtsBackWards(cols, snake, row);
                }
            }
        }

        private static void AddElemtsBackWards(int cols, string snake, int row)
        {
            for (int col = cols - 1; col >= 0; col--)
            {
                matrix[row, col] = snake[count++];
                if (count == snake.Length)
                {
                    count = 0;
                }
            }
        }

        private static void AddElemntsStraightForwads(int cols, string snake, int row)
        {
            for (int col = 0; col < cols; col++)
            {

                matrix[row, col] = snake[count++];
                if (count == snake.Length)
                {
                    count = 0;
                }
            }
        }
    }
}
