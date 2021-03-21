namespace P02.SquaresInMatrix
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class StartUp
    {
        private static char[,] matrix;
        private static int countOfEqualSquare;
        public static void Main()
        {
            var lengthArgs = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = lengthArgs[0];
            var cols = lengthArgs[1];

            matrix = new char[rows, cols];

            FillMatrix(matrix);
            LookForEqualSquare(rows, cols);
            Console.WriteLine(countOfEqualSquare);
        }

        private static void LookForEqualSquare(int rows, int cols)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    CheckIfSquareIsEqual(row, col);
                }
            }
        }

        private static void CheckIfSquareIsEqual(int row, int col)
        {
            var currSymbol = matrix[row, col];
            var symbolToTheRight = matrix[row, col + 1];
            var symbolDown = matrix[row + 1, col];
            var sumbolDiagonal = matrix[row + 1, col + 1];

            var isEqualRight = currSymbol == symbolToTheRight;
            var isEqualDown = currSymbol == symbolDown;
            var isEqualDiagonal = currSymbol == sumbolDiagonal;

            if (isEqualRight && isEqualDown && isEqualDiagonal)
            {
                countOfEqualSquare++;
            }
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var args = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = args[col];
                }
            }
        }
    }
}
