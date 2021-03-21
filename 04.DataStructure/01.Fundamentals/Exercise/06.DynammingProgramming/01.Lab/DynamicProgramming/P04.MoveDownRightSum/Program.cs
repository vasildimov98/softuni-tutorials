namespace P04.MoveDownRightSum
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var matrix = new int[rows, cols];
            ReadMatrix(matrix);

            var sumMatrix = new int[rows, cols];
            CreateSumMatrix(matrix, sumMatrix);

            var path = new Stack<string>();
            FindPathBackWards(sumMatrix, path, rows, cols);
            Console.WriteLine(string.Join(" ", path));
        }

        private static void FindPathBackWards(int[,] sumMatrix, Stack<string> path, int rows, int cols)
        {
            var row = rows - 1;
            var col = cols - 1;
            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");

                var upperNum = sumMatrix[row - 1, col];
                var leftNumb = sumMatrix[row, col - 1];

                if (upperNum > leftNumb) row--;
                else col--;
            }

            path.Push($"[{row}, {col}]");

            while (row > 0)
                path.Push($"[{--row}, {col}]");

            while (col > 0)
                path.Push($"[{row}, {--col}]");
        }

        private static void CreateSumMatrix(int[,] matrix, int[,] sumMatrix)
        {
            const int firstRow = 0;
            const int firstCol = 0;
            sumMatrix[firstRow, firstCol] = matrix[firstRow, firstCol];

            CreateFirstRow(matrix, sumMatrix);
            CreateFirstCol(matrix, sumMatrix);
            CreateRestOfMatrix(matrix, sumMatrix);
        }

        private static void CreateRestOfMatrix(int[,] matrix, int[,] sumMatrix)
        {
            for (int row = 1; row < sumMatrix.GetLength(0); row++)
            {
                for (int col = 1; col < sumMatrix.GetLength(1); col++)
                {
                    var upperNum = sumMatrix[row - 1, col];
                    var leftNum = sumMatrix[row, col - 1];

                    var maxNumber = Math.Max(upperNum, leftNum);

                    sumMatrix[row, col] = matrix[row, col] + maxNumber;
                }
            }
        }

        private static void CreateFirstCol(int[,] matrix, int[,] sumMatrix, int firstCol = 0)
        {
            for (int currRow = 1; currRow < sumMatrix.GetLength(0); currRow++)
            {
                sumMatrix[currRow, firstCol] = matrix[currRow, firstCol] + sumMatrix[currRow - 1, firstCol];
            }
        }

        private static void CreateFirstRow(int[,] matrix, int[,] sumMatrix, int firstRow = 0)
        {
            for (int currCol = 1; currCol < sumMatrix.GetLength(1); currCol++)
            {
                sumMatrix[firstRow, currCol] = matrix[firstRow, currCol] + sumMatrix[firstRow, currCol - 1];
            }
        }

        //private static void PrintMatrix(int[,] matrixToPrint)
        //{
        //    for (int row = 0; row < matrixToPrint.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < matrixToPrint.GetLength(1); col++)
        //        {
        //            Console.Write($"{matrixToPrint[row, col]} ");
        //        }

        //        Console.WriteLine();
        //    }
        //}

        private static void ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
