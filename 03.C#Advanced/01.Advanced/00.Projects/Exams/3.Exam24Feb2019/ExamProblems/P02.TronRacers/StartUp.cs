using System;
using System.Linq;

namespace P02.TronRacers
{
    class StartUp
    {
        private static char[][] matrix;
        static void Main()
        {
            var sizeOfMatrix = int.Parse(Console.ReadLine());
            matrix = new char[sizeOfMatrix][];

            var firstPlayerRow = 0;
            var firstPlayerCol = 0;

            var secondPlayerRow = 0;
            var secondPlayerCol = 0;

            FillMatrixAndFindPlayers(sizeOfMatrix,
                ref firstPlayerRow,
                ref firstPlayerCol,
                ref secondPlayerRow,
                ref secondPlayerCol);

            var firstPlayerDied = false;
            var secondPlayerDied = false;

            while (true)
            {
                var moves = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var firstPlayerMove = moves[0];
                MoveFirstPlayer(sizeOfMatrix,
                    ref firstPlayerRow,
                    ref firstPlayerCol,
                    ref firstPlayerDied,
                    firstPlayerMove);

                if (firstPlayerDied)
                {
                    break;
                }

                var secondPlayerMove = moves[1];
                MoveSecondPlayer(sizeOfMatrix,
                    ref secondPlayerRow,
                    ref secondPlayerCol,
                    ref secondPlayerDied,
                    secondPlayerMove);

                if (secondPlayerDied)
                {
                    break;
                }
            }

            PrintMatrix();
        }

        private static void MoveSecondPlayer(int sizeOfMatrix,
            ref int row,
            ref int col,
            ref bool secondPlayerDied,
            string secondPlayerMove)
        {
            if (secondPlayerMove == "up")
            {
                row--;
                if (ValidateMove(row, col))
                {
                    secondPlayerDied = ChangeSecondPlayerPosition(row,
                        col,
                        secondPlayerDied);
                }
                else
                {
                    row += sizeOfMatrix;
                    secondPlayerDied = ChangeSecondPlayerPosition(row,
                        col,
                        secondPlayerDied);
                }
            }
            else if (secondPlayerMove == "down")
            {
                row++;
                if (ValidateMove(row, col))
                {
                    secondPlayerDied = ChangeSecondPlayerPosition(row,
                        col,
                        secondPlayerDied);
                }
                else
                {
                    row -= sizeOfMatrix;
                    secondPlayerDied = ChangeSecondPlayerPosition(row,
                        col,
                        secondPlayerDied);
                }
            }
            else if (secondPlayerMove == "right")
            {
                col++;
                if (ValidateMove(row, col))
                {
                    secondPlayerDied = ChangeSecondPlayerPosition(row,
                        col,
                        secondPlayerDied);
                }
                else
                {
                    col -= sizeOfMatrix;
                    secondPlayerDied = ChangeSecondPlayerPosition(row,
                        col,
                        secondPlayerDied);
                }
            }
            else if (secondPlayerMove == "left")
            {
                col--;
                if (ValidateMove(row, col))
                {
                    secondPlayerDied = ChangeSecondPlayerPosition(row,
                        col,
                        secondPlayerDied);
                }
                else
                {
                    col += sizeOfMatrix;
                    secondPlayerDied = ChangeSecondPlayerPosition(row,
                        col,
                        secondPlayerDied);
                }
            }
        }

        private static bool ChangeSecondPlayerPosition(int row,
            int col,
            bool secondPlayerDied)
        {
            var symbol = matrix[row][col];

            if (symbol == 'f')
            {
                matrix[row][col] = 'x';
                secondPlayerDied = true;
            }
            else
            {
                matrix[row][col] = 's';
            }

            return secondPlayerDied;
        }

        private static void MoveFirstPlayer(int sizeOfMatrix,
            ref int row,
            ref int col,
            ref bool firstPlayerDied,
            string firstPlayerMove)
        {
            if (firstPlayerMove == "up")
            {
                row--;

                if (ValidateMove(row, col))
                {
                    firstPlayerDied = ChangeFirstPlayerPosition(row,
                        col,
                        firstPlayerDied);
                }
                else
                {
                    row += sizeOfMatrix;
                    firstPlayerDied = ChangeFirstPlayerPosition(row,
                        col,
                        firstPlayerDied);
                }
            }
            else if (firstPlayerMove == "down")
            {
                row++;

                if (ValidateMove(row, col))
                {
                    firstPlayerDied = ChangeFirstPlayerPosition(row,
                        col,
                        firstPlayerDied);
                }
                else
                {
                    row -= sizeOfMatrix;
                    firstPlayerDied = ChangeFirstPlayerPosition(row,
                        col,
                        firstPlayerDied);
                }
            }
            else if (firstPlayerMove == "right")
            {
                col++;

                if (ValidateMove(row, col))
                {
                    firstPlayerDied = ChangeFirstPlayerPosition(row,
                        col,
                        firstPlayerDied);
                }
                else
                {
                    col -= sizeOfMatrix;
                    firstPlayerDied = ChangeFirstPlayerPosition(row,
                        col,
                        firstPlayerDied);
                }
            }
            else if (firstPlayerMove == "left")
            {
                col--;

                if (ValidateMove(row, col))
                {
                    firstPlayerDied = ChangeFirstPlayerPosition(row,
                        col,
                        firstPlayerDied);
                }
                else
                {
                    col += sizeOfMatrix;
                    firstPlayerDied = ChangeFirstPlayerPosition(row,
                        col,
                        firstPlayerDied);
                }
            }
        }

        private static bool ChangeFirstPlayerPosition(int row, int col, bool firstPlayerDied)
        {
            var symbol = matrix[row][col];

            if (symbol == 's')
            {
                matrix[row][col] = 'x';
                firstPlayerDied = true;
            }
            else
            {
                matrix[row][col] = 'f';
            }

            return firstPlayerDied;
        }

        private static bool ValidateMove(int row, int col)
        {
            if (row < 0
                || row >= matrix.Length
                || col < 0
                || col >= matrix[row].Length)
            {
                return false;
            }

            return true;
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
        private static void FillMatrixAndFindPlayers(int sizeOfMatrix,
            ref int firstPlayerRow,
            ref int firstPlayerCol,
            ref int secondPlayerRow,
            ref int secondPlayerCol)
        {
            var firstPlayerFound = false;
            var secondPlayerFound = false;

            for (int row = 0; row < sizeOfMatrix; row++)
            {
                var currentRow = Console
                    .ReadLine()
                    .ToCharArray();

                matrix[row] = currentRow;

                if (!firstPlayerFound || !secondPlayerFound)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        var symbol = matrix[row][col];

                        if (symbol == 'f')
                        {
                            firstPlayerRow = row;
                            firstPlayerCol = col;

                            firstPlayerFound = true;
                        }

                        if (symbol == 's')
                        {
                            secondPlayerRow = row;
                            secondPlayerCol = col;

                            secondPlayerFound = true;
                        }
                    }
                }
            }
        }
    }
}
