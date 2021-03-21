namespace P00.EightQueensProblems
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private const char QUEEN = '*';
        private const char DASH = '-';

        private const int SIZE = 8;
        private const int DIAGONAL_SIZE = 15;

        private static bool[,] chessboard = new bool[SIZE, SIZE];
        private static int countOfSolution = 0;

        private readonly static bool[] attackedCols = new bool[SIZE];
        private readonly static bool[] attackedLeftDiagonal = new bool[DIAGONAL_SIZE];
        private readonly static bool[] attackedRightDiagonal = new bool[DIAGONAL_SIZE];
        static void Main()
        {
            FindAllSolution(0);
            Console.WriteLine(countOfSolution);
        }

        private static void FindAllSolution(int row)
        {
            if (row == SIZE)
            {
                countOfSolution++;
                PrintSolution();
                return;
            }

            for (int col = 0; col < SIZE; col++)
            {
                if(!CanPlaceQueen(row, col))
                {
                    MarkAllInvalidCell(row, col);
                    FindAllSolution(row + 1);
                    UnmarkAllInvalidCell(row, col);
                }
            }
        }

        private static void UnmarkAllInvalidCell(int row, int col)
        {
            var leftDiagonalIndex = col >= row ? col - row : DIAGONAL_SIZE - (row - col);

            chessboard[row, col] = false;
            attackedCols[col] = false;
            attackedLeftDiagonal[leftDiagonalIndex] = false;
            attackedRightDiagonal[row + col] = false;
        }

        private static void MarkAllInvalidCell(int row, int col)
        {
            var leftDiagonalIndex = col >= row ? col - row : DIAGONAL_SIZE - (row - col);

            chessboard[row, col] = true;
            attackedCols[col] = true;
            attackedLeftDiagonal[leftDiagonalIndex] = true;
            attackedRightDiagonal[row + col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var leftDiagonalIndex = col >= row ? col - row : DIAGONAL_SIZE - (row - col);

            return attackedCols[col]
                || attackedLeftDiagonal[leftDiagonalIndex]
                || attackedRightDiagonal[row + col];
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    if (!chessboard[row, col])
                        Console.Write($"{DASH} ");
                    else Console.Write($"{QUEEN} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
