namespace P01.DiagonalDifference
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class StartUp
    {
        public static void Main()
        {
            var sizeOfSquareMatrix = int.Parse(Console.ReadLine());

            var matrix = new int[sizeOfSquareMatrix, sizeOfSquareMatrix];

            FillMatrix(matrix);
            int absDiffBetweenDiagonalsOfTheMatrix
                = GetDiffBetweenDiagonals(sizeOfSquareMatrix, matrix);

            Console.WriteLine(absDiffBetweenDiagonalsOfTheMatrix);
        }

        private static int GetDiffBetweenDiagonals(int sizeOfSquareMatrix, int[,] matrix)
        {
            var primaryDiagonalSum = 0;
            var secondaryDiagonalSum = 0;

            for (int i = 0; i < sizeOfSquareMatrix; i++)
            {
                primaryDiagonalSum += matrix[i, i];
                secondaryDiagonalSum += matrix[i, sizeOfSquareMatrix - 1 - i];
            }

            var absDiffBetweenDiagonalsOfTheMatrix = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            return absDiffBetweenDiagonalsOfTheMatrix;
        }

        private static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var args = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = args[col];
                }
            }
        }
    }
}
