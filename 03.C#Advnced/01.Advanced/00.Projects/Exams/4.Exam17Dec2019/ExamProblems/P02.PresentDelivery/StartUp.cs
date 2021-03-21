using System;
using System.Linq;

namespace P02.PresentDelivery
{
    class StartUp
    {
        private static string[][] matrix;

        private static int countOfPresent;
        private static int countOfGoodChildren;
        private static int countOfPresentGivenToGoodChildren;
        static void Main()
        {
            countOfPresent = int.Parse(Console.ReadLine());
            var sizeOfNeighbour = int.Parse(Console.ReadLine());

            matrix = new string[sizeOfNeighbour][];
            var santaRowIndex = 0;
            var santaColIndex = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                var currRow = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                matrix[row] = currRow;
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == "S")
                    {
                        santaRowIndex = row;
                        santaColIndex = col;
                    }
                    else if (matrix[row][col] == "V")
                    {
                        countOfGoodChildren++;
                    }
                }
            }

            var santaIsEmty = false;
            while (true)
            {
                var move = Console.ReadLine();

                if (move == "Christmas morning")
                {
                    break;
                }

                var nextRow = santaRowIndex;
                var nextCol = santaColIndex;

                ChangeToNewPosition(move, ref nextRow, ref nextCol);

                if (!ValidateCell(nextRow, nextCol) || countOfPresent <= 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    break;
                }

                var symbol = matrix[nextRow][nextCol];

                if (symbol == "V")
                {
                    countOfPresent--;
                    countOfPresentGivenToGoodChildren++;
                }
                else if (symbol == "C")
                {
                    //left
                    if (LookForChildren(nextRow, nextCol - 1))
                    {
                        countOfPresent--;
                        if (countOfPresent == 0)
                        {
                            santaIsEmty = true;
                        }
                    }

                    //right
                    if (LookForChildren(nextRow, nextCol + 1))
                    {
                        countOfPresent--;
                        if (countOfPresent == 0)
                        {
                            santaIsEmty = true;
                        }
                    }

                    //up
                    if (LookForChildren(nextRow - 1, nextCol))
                    {
                        countOfPresent--;
                        if (countOfPresent == 0)
                        {
                            santaIsEmty = true;
                        }
                    }

                    //down
                    if (LookForChildren(nextRow + 1, nextCol))
                    {
                        countOfPresent--;
                        if (countOfPresent == 0)
                        {
                            santaIsEmty = true;
                        }
                    }
                }

                MoveSanta(ref santaRowIndex,
                    ref santaColIndex,
                    nextRow,
                    nextCol);

                if (santaIsEmty)
                {
                    if (countOfPresentGivenToGoodChildren != countOfGoodChildren)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                    }
                    break;
                }
            }


            PrintMatrix();

            if (countOfPresentGivenToGoodChildren == countOfGoodChildren)
            {
                Console.WriteLine($"Good job, Santa! {countOfPresentGivenToGoodChildren} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {countOfGoodChildren - countOfPresentGivenToGoodChildren} nice kid/s.");
            }
        }

        private static void MoveSanta(ref int santaRowIndex,
            ref int santaColIndex,
            int row,
            int col)
        {
            matrix[santaRowIndex][santaColIndex] = "-";
            matrix[row][col] = "S";

            santaRowIndex = row;
            santaColIndex = col;
        }

        static bool LookForChildren(int row, int col)
        {

            if (countOfPresent == 0)
            {
                return false;
            }

            if (matrix[row][col] == "X")
            {
                matrix[row][col] = "-";
                return true;
            }
            else if (matrix[row][col] == "V")
            {
                matrix[row][col] = "-";
                countOfPresentGivenToGoodChildren++;
                return true;
            }

            return false;
        }
        private static void ChangeToNewPosition(string move, ref int row, ref int col)
        {
            switch (move)
            {
                case "up":
                    row--;
                    break;
                case "down":
                    row++;
                    break;
                case "left":
                    col--;
                    break;
                case "right":
                    col++;
                    break;
            }
        }

        static bool ValidateCell(int row, int col)
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
        static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
