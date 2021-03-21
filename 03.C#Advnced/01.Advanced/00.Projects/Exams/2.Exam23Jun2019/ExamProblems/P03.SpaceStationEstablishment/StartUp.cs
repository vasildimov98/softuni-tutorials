using System;

namespace P03.SpaceStationEstablishment
{
    class StartUp
    {
        private const int STAR_POWER_ENERGY_NEEDED = 50;
        private static int energyCollected;
        private static char[][] galaxy;
        private static int playerRow;
        private static int playerCol;
        static void Main()
        {
            var matrixSizeRowAndCol = int.Parse(Console.ReadLine());

            galaxy = new char[matrixSizeRowAndCol][];
            var found = false;
           
            FillMatrix(ref found, playerRow, playerCol);
            var wentIntoTheVoid = false;
            while (true)
            {
                var nextRow = playerRow;
                var nextCol = playerCol;
                var move = Console.ReadLine();

                ChangePosition(ref nextRow, ref nextCol, move);

                if (ValidateIndex(nextRow, nextCol))
                {
                    Move(ref nextRow, ref nextCol);

                    if (energyCollected == STAR_POWER_ENERGY_NEEDED)
                    {
                        break;
                    }
                }
                else
                {
                    galaxy[playerRow][playerCol] = '-';
                    wentIntoTheVoid = true;
                    break;
                }
            }

            if (wentIntoTheVoid)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {energyCollected}");
            PrintMatrix();
        }

        private static void Move(ref int nextRow, ref int nextCol)
        {
            var symbol = galaxy[nextRow][nextCol];

            if (char.IsDigit(symbol))
            {
                energyCollected += symbol - 48;
            }
            else if (symbol == 'O')
            {
                LookForTheOtherBlackHole(ref nextRow, ref nextCol);
            }

            galaxy[playerRow][playerCol] = '-';

            playerRow = nextRow;
            playerCol = nextCol;

            galaxy[playerRow][playerCol] = 'S';
        }

        private static void LookForTheOtherBlackHole(ref int nextRow, ref int nextCol)
        {
            galaxy[nextRow][nextCol] = '-';
            for (int row = 0; row < galaxy.Length; row++)
            {
                for (int col = 0; col < galaxy[row].Length; col++)
                {
                    if (galaxy[row][col] == 'O')
                    {
                        nextRow = row;
                        nextCol = col;
                    }
                }
            }
        }

        private static void ChangePosition(ref int nextRow, ref int nextCol, string move)
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

        private static void FillMatrix(ref bool found, int playerRow, int playerCol)
        {
            for (int row = 0; row < galaxy.Length; row++)
            {
                var rows = Console
                    .ReadLine()
                    .ToCharArray();

                galaxy[row] = rows;

                if (!found)
                {
                    for (int col = 0; col < galaxy[row].Length; col++)
                    {
                        if (galaxy[row][col] == 'S')
                        {
                            found = true;

                            playerRow = row;
                            playerCol = col;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < galaxy.Length; row++)
            {
                for (int col = 0; col < galaxy[row].Length; col++)
                {
                    Console.Write(galaxy[row][col]);
                }
                Console.WriteLine();
            }
        }

        private static bool ValidateIndex(int row, int col)
        {
            if (row < 0
                || row >= galaxy.Length
                || col < 0
                || col >= galaxy[row].Length)
            {
                return false;
            }

            return true;
        }
    }
}
