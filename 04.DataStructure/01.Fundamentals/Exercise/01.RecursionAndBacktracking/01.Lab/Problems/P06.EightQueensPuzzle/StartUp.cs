using System;
using System.Collections.Generic;

namespace P06.EightQueensPuzzle
{
    public class StartUp
    {
        //private static HashSet<int> impossibleRows;
        private static HashSet<int> impossibleCols;
        private static HashSet<int> impossibleLeftDiagonals;
        private static HashSet<int> impossibleRightDiagonals;

        private static int count;

        public static void Main()
        {
            //impossibleRows = new HashSet<int>();
            impossibleCols = new HashSet<int>();
            impossibleLeftDiagonals = new HashSet<int>();
            impossibleRightDiagonals = new HashSet<int>();

            const int N = 8;
            var board = new bool[N, N];
            FindAllSolution(board);
            Console.WriteLine(count);
        }

        private static void FindAllSolution(bool[,] board, int row = 0)
        {
            if (row == board.GetLength(1))
            {
                PrintCurrSolution(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (IsValidCell(row, col))
                {
                    board[row, col] = true;

                    //impossibleRows.Add(row);
                    impossibleCols.Add(col);
                    impossibleLeftDiagonals.Add(row - col);
                    impossibleRightDiagonals.Add(row + col);

                    FindAllSolution(board, row + 1);

                    board[row, col] = false;

                    //impossibleRows.Remove(row);
                    impossibleCols.Remove(col);
                    impossibleLeftDiagonals.Remove(row - col);
                    impossibleRightDiagonals.Remove(row + col);
                }
            }
        }

        private static bool IsValidCell(int row, int col)
        {
            return //!impossibleRows.Contains(row) &&
                !impossibleCols.Contains(col) &&
                !impossibleLeftDiagonals.Contains(row - col) &&
                !impossibleRightDiagonals.Contains(row + col);
        }

        private static void PrintCurrSolution(bool[,] board)
        {
            count++;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] ? "* " : "- ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
