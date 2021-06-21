namespace P02.Snake
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var snakeRow = -1;
            var snakeCol = -1;

            var sizeOfMatrix = int.Parse(Console.ReadLine());

            var matrix = new char[sizeOfMatrix, sizeOfMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currRow = Console
                    .ReadLine()
                    .ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];

                    if (currRow[col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            var countOfEatenFood = 0;
            while (countOfEatenFood != 10)
            {
                var currMove = Console.ReadLine();

                var tempRow = snakeRow;
                var tempCol = snakeCol;

                switch (currMove)
                {
                    case "up":
                        tempRow--;
                        break;
                    case "down":
                        tempRow++;
                        break;
                    case "left":
                        tempCol--;
                        break;
                    case "right":
                        tempCol++;
                        break;
                }

                if (ValidateMove(matrix, tempRow, tempCol))
                {
                    var currPosition = matrix[tempRow, tempCol];
                    if (currPosition == '*')
                    {
                        countOfEatenFood++;
                    }
                    else if (currPosition == 'B')
                    {
                        matrix[tempRow, tempCol] = '.';

                        var isFound = false;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'B')
                                {
                                    tempRow = row;
                                    tempCol = col;

                                    isFound = true;
                                    break;
                                }
                            }

                            if (isFound)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    matrix[snakeRow, snakeCol] = '.';
                    break;
                }

                matrix[snakeRow, snakeCol] = '.';
                matrix[tempRow, tempCol] = 'S';
                snakeRow = tempRow;
                snakeCol = tempCol;
            }

            if (countOfEatenFood < 10)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {countOfEatenFood}");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
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

        private static bool ValidateMove(char[,] matrix, int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }
    }
}
