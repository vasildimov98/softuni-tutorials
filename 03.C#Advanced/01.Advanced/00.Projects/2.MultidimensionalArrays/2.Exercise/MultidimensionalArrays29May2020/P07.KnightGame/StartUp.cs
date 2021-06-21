namespace P07.KnightGame
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Schema;

    public class StartUp
    {
        private static char[][] chessBoard;
        private static int countOfRemovedKnights = 0;
        private static int knightRowWithMaxCount = -1; 
        private static int knightColWithMaxCount = -1;
        public static void Main()
        {
            var sizeOfTheBoard = int.Parse(Console.ReadLine());
            chessBoard = new char[sizeOfTheBoard][];
            GetChessBoarFilled();
            GetCountOfRemovedKnights();
            Console.WriteLine(countOfRemovedKnights);
        }

        private static void GetCountOfRemovedKnights()
        {
            while (true)
            {
                var maxCountOfKnightAttacks
                    = GetMaxCountOfKnightAttack();

                if (maxCountOfKnightAttacks == 0)
                {
                    break;
                }

                chessBoard[knightRowWithMaxCount][knightColWithMaxCount] = '0';
                countOfRemovedKnights++;
            }
        }

        private static int GetMaxCountOfKnightAttack()
        {
            int maxCountOfKnightAttacks = 0;

            for (int row = 0; row < chessBoard.Length; row++)
            {
                for (int col = 0; col < chessBoard[row].Length; col++)
                {
                    if (chessBoard[row][col] == 'K')
                    {
                        var countOfKnightAttacks
                            = GetKnightsAttackPossibility(row, col);

                        if (countOfKnightAttacks > maxCountOfKnightAttacks)
                        {
                            maxCountOfKnightAttacks
                                = countOfKnightAttacks;
                            knightRowWithMaxCount = row;
                            knightColWithMaxCount = col;
                        }
                    }
                }
            }

            return maxCountOfKnightAttacks;
        }

        private static int GetKnightsAttackPossibility(int row, int col)
        {
            var count = 0;
            //up 2 and right 1
            if (ValidateCoordinates(row - 2, col + 1))
            {
                count++;
            }

            //up 2 and left 1
            if (ValidateCoordinates(row - 2, col - 1))
            {
                count++;
            }

            //up 1 and right 2
            if (ValidateCoordinates(row - 1, col + 2))
            {
                count++;
            }
            
            //up 1 and left 2
            if (ValidateCoordinates(row - 1, col - 2))
            {
                count++;
            }
            
            //down 2 and right 1
            if (ValidateCoordinates(row + 2, col + 1))
            {
                count++;
            }

            //down 2 and left 1
            if (ValidateCoordinates(row + 2, col - 1))
            {
                count++;
            }

            //down 1 and right 2
            if (ValidateCoordinates(row + 1, col + 2))
            {
                count++;
            }

            //down 1 and left 2
            if (ValidateCoordinates(row + 1, col - 2))
            {
                count++;
            }

            return count;
        }

        private static bool ValidateCoordinates(int row, int col)
        {
            return row >= 0
                && row < chessBoard.Length
                && col >= 0
                && col < chessBoard[row].Length
                && chessBoard[row][col] == 'K';
        }

        private static void GetChessBoarFilled()
        {
            for (int row = 0; row < chessBoard.Length; row++)
            {
                var charArr = Console
                    .ReadLine()
                    .TrimEnd()
                    .ToCharArray();

                chessBoard[row] = charArr;
            }
        }
    }
}
