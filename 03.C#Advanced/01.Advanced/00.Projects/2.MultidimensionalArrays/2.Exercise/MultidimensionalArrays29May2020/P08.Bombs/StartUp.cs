namespace P08.Bombs
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[,] matrix;
        private static int countOfAliveCells;
        private static long sumOfAliveCells;
        public static void Main()
        {
            var sizeOfMatrix
                = int.Parse(Console.ReadLine());

            matrix = new int[sizeOfMatrix, sizeOfMatrix];
            GetMatrixFilled(sizeOfMatrix);

            var coordinatesArgs = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            if (sizeOfMatrix != 0)
            {
                ProceedAllBombs(coordinatesArgs);
                FindAllAliveCells();
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Alive cells: {countOfAliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");
            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void FindAllAliveCells()
        {
            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    countOfAliveCells++;
                    sumOfAliveCells += cell;
                }
            }
        }

        private static void ProceedAllBombs(string[] coordinatesArgs)
        {
            foreach (var coordinate in coordinatesArgs)
            {
                var dimensions = coordinate
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                var row = dimensions[0];
                var col = dimensions[1];

                if (matrix[row, col] > 0)
                {
                    ExplodeBomb(row, col);
                }
            }
        }

        private static void ExplodeBomb(int row, int col)
        {
            var value = matrix[row, col];
            SubtractTheValueOfAllCellsAroundTheBomb(row, col, value);
            matrix[row, col] = 0;
        }

        private static void SubtractTheValueOfAllCellsAroundTheBomb(int row, int col, int value)
        {
            //up
            if (ValidateIfCell(row - 1, col))
            {
                SubtractCellsValue(row - 1, col, value);
            }

            //up right
            if (ValidateIfCell(row - 1, col + 1))
            {
                SubtractCellsValue(row - 1, col + 1, value);
            }

            //up left
            if (ValidateIfCell(row - 1, col - 1))
            {
                SubtractCellsValue(row - 1, col - 1, value);
            }

            //right
            if (ValidateIfCell(row, col + 1))
            {
                SubtractCellsValue(row, col + 1, value);
            }

            //left
            if (ValidateIfCell(row, col - 1))
            {
                SubtractCellsValue(row, col - 1, value);
            }

            //down
            if (ValidateIfCell(row + 1, col))
            {
                SubtractCellsValue(row + 1, col, value);
            }

            //down right
            if (ValidateIfCell(row + 1, col + 1))
            {
                SubtractCellsValue(row + 1, col + 1, value);
            }

            //down left
            if (ValidateIfCell(row + 1, col - 1))
            {
                SubtractCellsValue(row + 1, col - 1, value);
            }
        }

        private static void SubtractCellsValue(int row, int col, int value)
        {
            matrix[row, col] -= value;
        }

        private static bool ValidateIfCell(int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1)
                && matrix[row, col] > 0;
        }

        private static void GetMatrixFilled(int sizeOfMatrix)
        {
            for (int row = 0; row < sizeOfMatrix; row++)
            {
                var rowsArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = rowsArgs[col];
                }
            }
        }
    }
}
