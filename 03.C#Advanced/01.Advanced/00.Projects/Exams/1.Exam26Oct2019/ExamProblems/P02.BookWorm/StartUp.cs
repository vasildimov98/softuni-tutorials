using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.BookWorm
{
    public class StartUp
    {
        static void Main()
        {
            var initialString = Console
                .ReadLine()
                .ToCharArray();

            var stack = new Stack<char>(initialString);

            var rowsLength = int.Parse(Console.ReadLine());

            var matrix = new char[rowsLength][];
            var foundPlayer = false;
            var playerRow = -1;
            var playerCol = -1;
            FillMatrix(rowsLength,
                matrix,
                ref foundPlayer,
                ref playerRow,
                ref playerCol);

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                var currPlayerRow = playerRow;
                var currPlayerCol = playerCol;
                ChangePosition(command, ref currPlayerRow, ref currPlayerCol);

                if (ValidateIndex(currPlayerRow, currPlayerCol, matrix))
                {
                    MovePlayer(stack, matrix,
                        ref playerRow,
                        ref playerCol,
                        currPlayerRow,
                        currPlayerCol);
                }
                else
                {
                    Punish(stack);
                }
            }

            Console.WriteLine(string.Join("", stack.Reverse()));
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
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

        private static void MovePlayer(Stack<char> stack,
            char[][] matrix,
            ref int playerRow,
            ref int playerCol,
            int currPlayerRow,
            int currPlayerCol)
        {
            var symbol = matrix[currPlayerRow][currPlayerCol];

            if (char.IsLetter(symbol))
            {
                stack.Push(symbol);
            }

            matrix[playerRow][playerCol] = '-';
            matrix[currPlayerRow][currPlayerCol] = 'P';
            playerRow = currPlayerRow;
            playerCol = currPlayerCol;
        }

        private static void Punish(Stack<char> stack)
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }
        }

        private static bool ValidateIndex(int row, int col, char[][] matrix)
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
        private static void ChangePosition(string command, ref int currPlayerRow, ref int currPlayerCol)
        {
            switch (command)
            {
                case "up":
                    currPlayerRow--;
                    break;
                case "down":
                    currPlayerRow++;
                    break;
                case "left":
                    currPlayerCol--;
                    break;
                case "right":
                    currPlayerCol++;
                    break;
            }
        }

        private static void FillMatrix(int rowsLength,
            char[][] matrix,
            ref bool foundPlayer,
            ref int playerRow,
            ref int playerCol)
        {
            for (int row = 0; row < rowsLength; row++)
            {
                var rows = Console
                    .ReadLine()
                    .ToCharArray();

                matrix[row] = rows;
                if (!foundPlayer)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'P')
                        {
                            foundPlayer = true;
                            playerRow = row;
                            playerCol = col;
                        }
                    }
                }
            }
        }
    }
}
