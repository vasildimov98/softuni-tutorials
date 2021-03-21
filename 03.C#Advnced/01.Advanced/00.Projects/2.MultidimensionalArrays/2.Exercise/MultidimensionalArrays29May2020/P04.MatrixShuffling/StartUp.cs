namespace P04.MatrixShuffling
{
    using System;
    using System.Linq;
    using System.Reflection.PortableExecutable;

    public class StartUp
    {
        private static string[,] matrix;
        public static void Main()
        {
            var dimensions = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];
            matrix = new string[rows, cols];

            GetMatrixFilled(rows, cols);
            ProceedCommands();


        }

        private static void ProceedCommands()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var cmdArgs = command
                    .Split(' ', StringSplitOptions.None)
                    .ToArray();

                if (cmdArgs[0] != "swap" || cmdArgs.Length != 5)
                {
                    Console.WriteLine("Invalid input!");

                    continue;
                }

                var row1 = int.Parse(cmdArgs[1]);
                var col1 = int.Parse(cmdArgs[2]);

                var row2 = int.Parse(cmdArgs[3]);
                var col2 = int.Parse(cmdArgs[4]);

                if (!ValidateCoordinates(row1, col1) || !ValidateCoordinates(row2, col2))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                SwapElements(row1, col1, row2, col2);
                PrintCurrentMatrix();
            }
        }

        private static void PrintCurrentMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        private static void SwapElements(int row1, int col1, int row2, int col2)
        {
            var temp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = temp;
        }

        private static bool ValidateCoordinates(int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1); 
        }

        private static void GetMatrixFilled(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var args = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = args[col];
                }
            }
        }
    }
}
