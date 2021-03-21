using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dimensions = Console
                .ReadLine()
                .Split(" ", 2, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new char[rows, cols];

            var playerRowIndex = -1;
            var playerColIndex = -1;

            for (int row = 0; row < rows; row++)
            {
                var data = Console
                    .ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRowIndex = row;
                        playerColIndex = col;
                    }
                }
            }

            var movements = Console.ReadLine();
            var stepOnBunny = false;
            var stepOutOfField = false;

            foreach (var move in movements)
            {
                var currPlayerRowIndex = playerRowIndex;
                var currPlayerColIndex = playerColIndex;

                switch (move)
                {
                    case 'L':
                        currPlayerColIndex--;
                        break;
                    case 'R':
                        currPlayerColIndex++;
                        break;
                    case 'U':
                        currPlayerRowIndex--;
                        break;
                    case 'D':
                        currPlayerRowIndex++;
                        break;
                }

                if (ValidateCell(currPlayerRowIndex, currPlayerColIndex, matrix))
                {
                    matrix[playerRowIndex, playerColIndex] = '.';

                    playerRowIndex = currPlayerRowIndex;
                    playerColIndex = currPlayerColIndex;

                    if (!LookForBunny(playerRowIndex, playerColIndex, matrix))
                    {
                        matrix[playerRowIndex, playerColIndex] = 'P';
                    }
                    else
                    {
                        stepOnBunny = true;
                    }
                }
                else
                {
                    stepOutOfField = true;
                    matrix[playerRowIndex, playerColIndex] = '.';
                }

                var bunnies = new List<int>();
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunnies.Add(row);
                            bunnies.Add(col);
                        }
                    }
                }

                for (int i = 0; i < bunnies.Count; i+=2)
                {
                    var bunnieRow = bunnies[i];
                    var bunnieCol = bunnies[i + 1];

                    SpreadBunnies(matrix, bunnieRow, bunnieCol);
                }

                if (LookForBunny(playerRowIndex, playerColIndex, matrix))
                {
                    stepOnBunny = true;
                }
               
                if (stepOutOfField || stepOnBunny)
                {
                    bunnies.Clear();
                    break;
                }
            }

            PrintMatrix(matrix);
            if (stepOutOfField)
            {
                Console.WriteLine($"won: {playerRowIndex} {playerColIndex}");
            }
            else if (stepOnBunny)
            {
                Console.WriteLine($"dead: {playerRowIndex} {playerColIndex}");
            }
        }

        static void SpreadBunnies(char[,] matrix, int row, int col)
        {
            //up
            if (row - 1 >= 0)
            {
                matrix[row - 1, col] = 'B';
            }

            //down
            if (row + 1 < matrix.GetLength(0))
            {
                matrix[row + 1, col] = 'B';
            }

            //left
            if (col - 1 >= 0)
            {
                matrix[row, col - 1] = 'B';
            }

            //right
            if (col + 1 < matrix.GetLength(1))
            {
                matrix[row, col + 1] = 'B';
            }
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        static bool ValidateCell(int row, int col, char[,] matrix)
        {
            if (row < 0
                || row >= matrix.GetLength(0)
                || col < 0
                || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }
        static bool LookForBunny(int row, int col, char[,] matrix)
        {
            if (matrix[row, col] != 'B')
            {
                return false;
            }
            return true;
        }
        static bool LookForPlayer(int row, int col, char[,] matrix)
        {
            if (matrix[row, col] != 'P')
            {
                return false;
            }
            return true;
        }
    }
}
