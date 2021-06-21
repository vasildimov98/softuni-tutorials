using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var chessBoard = ReadJaggedArray(rows);

            var currentKnightsInDanger = 0;
            var maxKnightsInDanger = 0;
            var maxKnightRowIndex = 0;
            var maxKnightColIndex = 0;
            var counter = 0;

            while (true)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < chessBoard[row].Length; col++)
                    {
                        //horizontally right two and one up
                        if (chessBoard[row][col] == 'K' && IsCellValid(row + 1, col + 2, chessBoard))
                        {
                            if (chessBoard[row + 1][col + 2] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        //horizontally right two and one down
                        if (chessBoard[row][col] == 'K' && IsCellValid(row - 1, col + 2, chessBoard))
                        {
                            if (chessBoard[row - 1][col + 2] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        //horizontally right one and two up
                        if (chessBoard[row][col] == 'K' && IsCellValid(row + 2, col + 1, chessBoard))
                        {
                            if (chessBoard[row + 2][col + 1] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        //horizontally right one and two down
                        if (chessBoard[row][col] == 'K' && IsCellValid(row - 2, col + 1, chessBoard))
                        {
                            if (chessBoard[row - 2][col + 1] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        //horizontally left two and one up
                        if (chessBoard[row][col] == 'K' && IsCellValid(row + 1, col - 2, chessBoard))
                        {
                            if (chessBoard[row + 1][col - 2] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        //horizontally left two and one down
                        if (chessBoard[row][col] == 'K' && IsCellValid(row - 1, col - 2, chessBoard))
                        {
                            if (chessBoard[row - 1][col - 2] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        //horizontally left one and two up
                        if (chessBoard[row][col] == 'K' && IsCellValid(row + 2, col - 1, chessBoard))
                        {
                            if (chessBoard[row + 2][col - 1] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        //horizontally left one and two down
                        if (chessBoard[row][col] == 'K' && IsCellValid(row - 2, col - 1, chessBoard))
                        {
                            if (chessBoard[row - 2][col - 1] == 'K')
                            {
                                currentKnightsInDanger++;
                            }
                        }

                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            maxKnightRowIndex = row;
                            maxKnightColIndex = col;
                        }
                        currentKnightsInDanger = 0;
                    }
                }

                if (maxKnightsInDanger != 0)
                {
                    chessBoard[maxKnightRowIndex][maxKnightColIndex] = '0';
                    counter++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(counter);
                    break;
                }
            }

            static bool IsCellValid(int row, int col, char[][] arr)
            {
                if (row < 0 ||
                    row >= arr.Length ||
                    col < 0 ||
                    col >= arr[row].Length)
                {
                    return false;
                }

                return true;
            }

            static void PrintMatix(string[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col] + "  ");
                    }

                    Console.WriteLine();
                }
            }
            static char[][] ReadJaggedArray(int rows)
            {
                var jaggedArray = new char[rows][];

                for (int row = 0; row < rows; row++)
                {
                    var currentCol = Console
                         .ReadLine()
                         .ToCharArray();

                    jaggedArray[row] = new char[rows];

                    jaggedArray[row] = currentCol;
                }
                return jaggedArray;
            }
        }
    }
}
