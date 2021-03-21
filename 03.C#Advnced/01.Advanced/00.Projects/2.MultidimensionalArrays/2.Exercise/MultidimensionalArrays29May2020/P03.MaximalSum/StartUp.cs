namespace P03.MaximalSum
{
    using System;
    using System.Linq;
    public class StartUp
    {
        private static int[,] matrix;
        private static int maxSumRow;
        private static int maxSumCol;
        public static void Main()
        {
            var dimensions = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            matrix = new int[rows, cols];
            GetMatrixFilled(rows, cols);
            var maxSum = 0;
            maxSum = LookForTheMaxSum(rows, cols, maxSum);
            PrintMatrixWithMaxSum(maxSum);
        }

        private static void PrintMatrixWithMaxSum(int maxSum)
        {
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = maxSumRow; row < maxSumRow + 3; row++)
            {
                for (int col = maxSumCol; col < maxSumCol + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static int LookForTheMaxSum(int rows, int cols, int maxSum)
        {
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    maxSum = GetMaxSum(maxSum, row, col);
                }
            }

            return maxSum;
        }

        private static int GetMaxSum(int maxSum, int row, int col)
        {
            var sum = matrix[row, col];
            sum += matrix[row, col + 1];
            sum += matrix[row, col + 2];
            sum += matrix[row + 1, col];
            sum += matrix[row + 1, col + 1];
            sum += matrix[row + 1, col + 2];
            sum += matrix[row + 2, col];
            sum += matrix[row + 2, col + 1];
            sum += matrix[row + 2, col + 2];

            if (sum > maxSum)
            {
                maxSum = sum;

                maxSumRow = row;
                maxSumCol = col;
            }

            return maxSum;
        }

        private static void GetMatrixFilled(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var args = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = args[col];
                }
            }
        }
    }
}
