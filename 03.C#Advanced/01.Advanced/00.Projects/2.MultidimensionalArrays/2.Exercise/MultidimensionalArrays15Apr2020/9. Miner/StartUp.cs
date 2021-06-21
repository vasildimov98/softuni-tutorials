using System;
using System.Linq;

namespace _9._Miner
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = rows;

            var movement = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var countForCoal = 0;
            var matrix = new char[rows, cols];
            var minerStarRowIndex = 0;
            var minerStarColIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                var data = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];

                    if (data[col] == 'c')
                    {
                        countForCoal++;
                    }
                    else if (data[col] == 's')
                    {
                        minerStarRowIndex = row;
                        minerStarColIndex = col;
                    }
                }
            }

            var stepOnGameOver = false;
            var foundAllCoal = false;

            foreach (var move in movement)
            {
                //left
                if (move == "left")
                {
                    if (ValidateCell(minerStarRowIndex, minerStarColIndex - 1, matrix))
                    {
                        minerStarColIndex--;
                        if (matrix[minerStarRowIndex, minerStarColIndex] == 'c')
                        {
                            countForCoal--;
                            matrix[minerStarRowIndex, minerStarColIndex] = '*';
                        }
                        else if (matrix[minerStarRowIndex, minerStarColIndex] == 'e')
                        {
                            stepOnGameOver = true;
                            break;
                        }
                    }
                }
                //right
                if (move == "right")
                {
                    if (ValidateCell(minerStarRowIndex, minerStarColIndex + 1, matrix))
                    {
                        minerStarColIndex++;
                        if (matrix[minerStarRowIndex, minerStarColIndex] == 'c')
                        {
                            countForCoal--;
                            matrix[minerStarRowIndex, minerStarColIndex] = '*';
                        }
                        else if (matrix[minerStarRowIndex, minerStarColIndex] == 'e')
                        {
                            stepOnGameOver = true;
                            break;
                        }
                    }
                }
                //up
                if (move == "up")
                {
                    if (ValidateCell(minerStarRowIndex - 1, minerStarColIndex, matrix))
                    {
                        minerStarRowIndex--;
                        if (matrix[minerStarRowIndex, minerStarColIndex] == 'c')
                        {
                            countForCoal--;
                            matrix[minerStarRowIndex, minerStarColIndex] = '*';
                        }
                        else if (matrix[minerStarRowIndex, minerStarColIndex] == 'e')
                        {
                            stepOnGameOver = true;
                            break;
                        }
                    }
                }
                //down 
                if (move == "down")
                {
                    if (ValidateCell(minerStarRowIndex + 1, minerStarColIndex, matrix))
                    {
                        minerStarRowIndex++;
                        if (matrix[minerStarRowIndex, minerStarColIndex] == 'c')
                        {
                            countForCoal--;
                            matrix[minerStarRowIndex, minerStarColIndex] = '*';
                        }
                        else if (matrix[minerStarRowIndex, minerStarColIndex] == 'e')
                        {
                            stepOnGameOver = true;
                            break;
                        }
                    }
                }

                if (countForCoal == 0)
                {
                    foundAllCoal = true;
                    break;
                }
            }

            if (foundAllCoal)
            {
                Console.WriteLine($"You collected all coals! ({minerStarRowIndex}, {minerStarColIndex})");
            }
            else if (stepOnGameOver)
            {
                Console.WriteLine($"Game over! ({minerStarRowIndex}, {minerStarColIndex})");
            }
            else
            {
                Console.WriteLine($"{countForCoal} coals left. ({minerStarRowIndex}, {minerStarColIndex})");
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
    }
}
