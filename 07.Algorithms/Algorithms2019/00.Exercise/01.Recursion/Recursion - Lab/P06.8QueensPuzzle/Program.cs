namespace P06._8QueensPuzzle
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        private const int SIZE = 8;
        private const char STAR = '*';
        private const char DASH = '-';

        private static int solutionsFound = 0;
        private static readonly bool[,] isQueenBoard = new bool[SIZE, SIZE];

        private readonly static HashSet<int> attackedCols = new HashSet<int>();
        private readonly static HashSet<int> attackedLeftDiagonal = new HashSet<int>();
        private readonly static HashSet<int> attackedRightDiagonal = new HashSet<int>();
        static void Main()
        {
            FindAllPossibleWays(0);
            Console.WriteLine(solutionsFound);
        }

        private static void FindAllPossibleWays(int row)
        {
            if (row == SIZE)
            {
                PrintChessboard();
                return;
            }

            for (int col = 0; col < SIZE; col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    MarkedAllAttackedPossition(row, col);
                    FindAllPossibleWays(row + 1);
                    UmmarkedAllAttackedPossition(row, col);
                }
            }
        }

        private static void UmmarkedAllAttackedPossition(int row, int col)
        {
            attackedCols.Remove(col);
            attackedLeftDiagonal.Remove(col - row);
            attackedRightDiagonal.Remove(row + col);
            isQueenBoard[row, col] = false;
        }

        private static void MarkedAllAttackedPossition(int row, int col)
        {
            attackedCols.Add(col);
            attackedLeftDiagonal.Add(col - row);
            attackedRightDiagonal.Add(row + col);
            isQueenBoard[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var isPositionOccupied = attackedCols.Contains(col)
                || attackedLeftDiagonal.Contains(col - row)
                || attackedRightDiagonal.Contains(row + col);

            return !isPositionOccupied;
        }

        private static void PrintChessboard()
        {
            solutionsFound++;
            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    if (isQueenBoard[row, col])
                        Console.Write($"{STAR} ");
                    else Console.Write($"{DASH} ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
