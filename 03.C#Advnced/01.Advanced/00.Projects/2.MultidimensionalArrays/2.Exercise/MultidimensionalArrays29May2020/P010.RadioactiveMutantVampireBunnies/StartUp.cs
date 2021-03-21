namespace P10.RadioactiveMutantVampireBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Cryptography;

    public class StartUp
    {
        private static char[][] gameField;

        private static int playerRow;
        private static int playerCol;

        private static bool IsWon;
        private static bool IsDead;

        private static Queue<int[]> bunniesCoordinates
            = new Queue<int[]>();
        public static void Main()
        {
            var dimensions = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            gameField = new char[rows][];
            GetGameFieldFilled(rows, cols);
            MovePlayerTillHeWinsOrDies();
            PrintResult();
        }

        private static void PrintResult()
        {
            PrintMatrix();

            if (IsWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        private static void PrintMatrix()
        {
            foreach (var row in gameField)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void MovePlayerTillHeWinsOrDies()
        {
            var playerGameMoves = Console.ReadLine();

            foreach (var move in playerGameMoves)
            {
                var currPlayerRow = playerRow;
                var currPlayerCol = playerCol;

                switch (move)
                {
                    case 'U':
                        currPlayerRow--;
                        break;
                    case 'D':
                        currPlayerRow++;
                        break;
                    case 'L':
                        currPlayerCol--;
                        break;
                    case 'R':
                        currPlayerCol++;
                        break;
                }

                gameField[playerRow][playerCol] = '.';

                PlayTheGame(currPlayerRow, currPlayerCol);

                if (IsWon)
                {
                    break;
                }
                else if (IsDead)
                {
                    playerRow = currPlayerRow;
                    playerCol = currPlayerCol;
                    break;
                }

                gameField[currPlayerRow][currPlayerCol] = 'P';

                playerRow = currPlayerRow;
                playerCol = currPlayerCol;
            }
        }

        private static void PlayTheGame(int currPlayerRow, int currPlayerCol)
        {
            var isInsideTheGameField = ValidatePlayerMove(currPlayerRow, currPlayerCol);

            if (!isInsideTheGameField)
            {
                IsWon = true;
            }

            if (isInsideTheGameField && LookForBunny(currPlayerRow, currPlayerCol))
            {
                IsDead = true;
            }

            GetBunniesSpread();

            if (!IsWon
                && !IsDead
                && bunniesCoordinates
                .Any(bn => bn[0] == currPlayerRow
                && bn[1] == currPlayerCol))
            {
                IsDead = true;
            }
        }

        private static void GetBunniesSpread()
        {
            var currCount = bunniesCoordinates.Count;

            for (int i = 0; i < currCount; i++)
            {
                var currCoordinates = bunniesCoordinates.Dequeue();

                var bunnyRow = currCoordinates[0];
                var bunnyCol = currCoordinates[1];

                //up
                if (ValidateBunnyMove(bunnyRow - 1, bunnyCol))
                {
                    gameField[bunnyRow - 1][bunnyCol] = 'B';

                    bunniesCoordinates.Enqueue(new[] { bunnyRow - 1, bunnyCol });
                }

                //down
                if (ValidateBunnyMove(bunnyRow + 1, bunnyCol))
                {
                    gameField[bunnyRow + 1][bunnyCol] = 'B';

                    bunniesCoordinates.Enqueue(new[] { bunnyRow + 1, bunnyCol });
                }

                //left
                if (ValidateBunnyMove(bunnyRow, bunnyCol - 1))
                {
                    gameField[bunnyRow][bunnyCol - 1] = 'B';

                    bunniesCoordinates.Enqueue(new[] { bunnyRow, bunnyCol - 1 });
                }

                //right
                if (ValidateBunnyMove(bunnyRow, bunnyCol + 1))
                {
                    gameField[bunnyRow][bunnyCol + 1] = 'B';

                    bunniesCoordinates.Enqueue(new[] { bunnyRow, bunnyCol + 1 });
                }
            }
        }

        private static bool LookForBunny(int row, int col)
        {
            return gameField[row][col] == 'B';
        }
        private static bool ValidatePlayerMove(int row, int col)
        {
            return row >= 0
                && row < gameField.Length
                && col >= 0
                && col < gameField[row].Length;
        }

        private static bool ValidateBunnyMove(int row, int col)
        {
            return row >= 0
                && row < gameField.Length
                && col >= 0
                && col < gameField[row].Length
                && gameField[row][col] != 'B';
        }
        private static void GetGameFieldFilled(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var charArr = Console
                    .ReadLine()
                    .Trim()
                    .ToCharArray();

                gameField[row] = charArr;

                for (int col = 0; col < cols; col++)
                {
                    if (gameField[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (gameField[row][col] == 'B')
                    {
                        bunniesCoordinates.Enqueue(new[] { row, col });
                    }
                }
            }
        }
    }
}
