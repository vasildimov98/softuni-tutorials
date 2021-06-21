using System;

namespace P02.Re_Volt
{
    class StartUp
    {
        private static char[][] matrix;
        private static int playerRow;
        private static int playerCol;
        static void Main()
        {
            var sizeOfMatrix = int.Parse(Console.ReadLine());
            var countOfCommands = int.Parse(Console.ReadLine());

            matrix = new char[sizeOfMatrix][];
            FillMatrix();

            var finishMarkIsReached = false;
            for (int i = 0; i < countOfCommands; i++)
            {
                var move = Console.ReadLine();

                var nextRow = playerRow;
                var nextCol = playerCol;

                ChangePosition(move, ref nextRow, ref nextCol);

                if (!ValidateMove(nextRow, nextCol))
                {
                    MovePlayerToOtherSide(sizeOfMatrix,
                        move,
                        ref nextRow,
                        ref nextCol);
                }

                if (matrix[nextRow][nextCol] == 'B')
                {
                    CorrectMove(1, move, ref nextRow, ref nextCol);
                }
                else if (matrix[nextRow][nextCol] == 'T')
                {
                    continue;
                }

                if (!ValidateMove(nextRow, nextCol))
                {
                    MovePlayerToOtherSide(sizeOfMatrix,
                        move,
                        ref nextRow,
                        ref nextCol);
                }

                if (matrix[nextRow][nextCol] == 'F')
                {
                    finishMarkIsReached = true;
                }

                MovePlayer(nextRow, nextCol);

                if (finishMarkIsReached)
                {
                    break;
                }
            }

            if (finishMarkIsReached)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            PrintMatrix();
        }

        private static void MovePlayer(int nextRow, int nextCol)
        {
            matrix[playerRow][playerCol] = '-';
            matrix[nextRow][nextCol] = 'f';

            playerRow = nextRow;
            playerCol = nextCol;
        }

        private static void MovePlayerToOtherSide(int sizeOfMatrix, string move, ref int nextRow, ref int nextCol)
        {
            if (move == "up")
            {
                nextRow += sizeOfMatrix;
            }
            else if (move == "down")
            {
                nextRow -= sizeOfMatrix;
            }
            else if (move == "left")
            {
                nextCol += sizeOfMatrix;
            }
            else if (move == "right")
            {
                nextCol -= sizeOfMatrix;
            }
        }

        private static void CorrectMove(int numberToCorrectWith, string move, ref int nextRow, ref int nextCol)
        {
            if (move == "up")
            {
                nextRow -= numberToCorrectWith;
            }
            else if (move == "down")
            {
                nextRow += numberToCorrectWith;
            }
            else if (move == "left")
            {
                nextCol -= numberToCorrectWith;
            }
            else if (move == "right")
            {
                nextCol += numberToCorrectWith;
            }
        }

        private static bool ValidateMove(int row, int col)
        {
            if (row < 0 ||
                row >= matrix.Length
                || col < 0
                ||col >= matrix[row].Length)
            {
                return false;
            }

            return true;
        }

        private static void ChangePosition(string move, ref int nextRow, ref int nextCol)
        {
            switch (move)
            {
                case "up":
                    nextRow--;
                    break;
                case "down":
                    nextRow++;
                    break;
                case "left":
                    nextCol--;
                    break;
                case "right":
                    nextCol++;
                    break;
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(matrix[row]);
            }
        }

        private static void FillMatrix()
        {
            var found = false;
            for (int row = 0; row < matrix.Length; row++)
            {
                var currRow = Console
                    .ReadLine()
                    .ToCharArray();

                matrix[row] = currRow;
                if (!found)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'f')
                        {
                            playerRow = row;
                            playerCol = col;
                        }
                    }
                }
            }
        }
    }
}
