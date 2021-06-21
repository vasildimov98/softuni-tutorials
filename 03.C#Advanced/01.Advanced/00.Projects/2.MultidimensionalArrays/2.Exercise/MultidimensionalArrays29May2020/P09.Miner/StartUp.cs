namespace P09.Miner
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    public class StartUp
    {
        private static char[,] field;
        private static int countOfCoal;

        private static int minerRow;
        private static int minerCol;

        public static void Main()
        {
            var fieldSize = int.Parse(Console.ReadLine());
            var minersMoves = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            field = new char[fieldSize, fieldSize];
            GetFieldFilled();
            var isDead = MoveMiner(minersMoves);
            PrintResult(isDead);
        }

        private static void PrintResult(bool isDead)
        {
            if (isDead)
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            else if (countOfCoal == 0)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{countOfCoal} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static bool MoveMiner(string[] minersMoves)
        {
            foreach (var move in minersMoves)
            {
                var currMinerRow = minerRow;
                var currMinerCol = minerCol;

                switch (move)
                {
                    case "up":
                        currMinerRow--;
                        break;
                    case "down":
                        currMinerRow++;
                        break;
                    case "left":
                        currMinerCol--;
                        break;
                    case "right":
                        currMinerCol++;
                        break;
                }

                if (!ValidateCurrMove(currMinerRow, currMinerCol))
                {
                    continue;
                }

                minerRow = currMinerRow;
                minerCol = currMinerCol;

                LookForCoal(currMinerRow, currMinerCol);

                if (countOfCoal == 0)
                {
                    break;
                }

                if (LookForTheEnd(currMinerRow, currMinerCol))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool LookForTheEnd(int row, int col)
        {
            return field[row, col] == 'e';
            
        }

        private static void LookForCoal(int row, int col)
        {
            if (field[row, col] == 'c')
            {
                field[row, col] = '*';
                countOfCoal--;
            }
        }

        private static bool ValidateCurrMove(int row, int col)
        {
            return row >= 0
                && row < field.GetLength(0)
                && col >= 0
                && col < field.GetLength(1);
        }

        private static void GetFieldFilled()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                var rowArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowArgs[col];

                    if (field[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }

                    if (field[row, col] == 'c')
                    {
                        countOfCoal++;
                    }
                }
            }
        }
    }
}
