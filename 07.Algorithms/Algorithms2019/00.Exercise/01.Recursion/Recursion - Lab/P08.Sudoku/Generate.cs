namespace P08.Sudoku
{
    using System;
    internal class Generate
    {
        private const int SIZE = 9;
        private const int SUB_GRID_SIZE = 3;
        private const int BASE = 0;
        private readonly int[][] sudoku;
        public Generate()
        {
            this.sudoku = new[]
            {
                new []{0, 0, 0, 0, 0, 0, 0, 0, 0},
                new []{0, 0, 0, 0, 0, 0, 0, 0, 0},
                new []{0, 0, 0, 0, 0, 0, 0, 0, 0},

                new []{0, 0, 0, 0, 0, 0, 0, 0, 0},
                new []{0, 0, 1, 0, 0, 0, 0, 0, 0},
                new []{0, 0, 0, 0, 0, 0, 2, 0, 0},

                new []{0, 0, 0, 0, 0, 0, 0, 0, 0},
                new []{0, 0, 0, 0, 0, 0, 0, 0, 0},
                new []{0, 0, 0, 0, 0, 0, 0, 0, 0},
            };
        }

        internal void Run()
        {
            PrintSolution();

            if (SolveSudoku())
                PrintSolution();
            else Console.WriteLine("Impossible to solve!");
        }

        private bool SolveSudoku()
        {
            var foundCell = FindEmptyCell();

            int row;
            int col;
            if (foundCell == null) return true;
            else
            {
                row = foundCell[0];
                col = foundCell[1];
            }

            for (int possibleNumb = 1; possibleNumb <= SIZE; possibleNumb++)
            {
                if (NumberIsSafeToPlace(possibleNumb, row, col))
                {
                    this.sudoku[row][col] = possibleNumb;

                    if (SolveSudoku()) return true;

                    this.sudoku[row][col] = BASE;
                }
            }

            return false;
        }

        private int[] FindEmptyCell()
        {
            for (int row = 0; row < SIZE; row++)
                for (int col = 0; col < SIZE; col++)
                    if (this.sudoku[row][col] == 0)
                        return new[] { row, col };
            return null;
        }

        private bool NumberIsSafeToPlace(int possibleNumb, int row, int col)
        {
            for (int c = 0; c < SIZE; c++)
                if (this.sudoku[row][c] == possibleNumb) return false;

            for (int r = 0; r < SIZE; r++)
                if (this.sudoku[r][col] == possibleNumb) return false;

            var startRow = row - row % SUB_GRID_SIZE;
            var startCol = col - col % SUB_GRID_SIZE;

            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (this.sudoku[r + startRow][c + startCol] == possibleNumb) return false;

            return true;
        }

        private void PrintSolution()
        {
            for (int row = 0; row < this.sudoku.Length; row++)
            {
                if (row != 0 && row % SUB_GRID_SIZE == 0)
                    Console.WriteLine("- - - - - - - - - - - -");
                
                for (int col = 0; col < this.sudoku[row].Length; col++)
                {
                    if (col != 0 && col % SUB_GRID_SIZE == 0)
                        Console.Write(" | ");

                    Console.Write($"{this.sudoku[row][col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}