using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class StartUp
    {
        private static int[,] matrix;
        private static long collectedStars;

        private static int evilRow;
        private static int evilCol;

        private static int IvoRow;
        private static int IvoCol;
        static void Main()
        {
            var dimensionsOfMatrix = SplitAndParseInput();

            var rows = dimensionsOfMatrix[0];
            var cols = dimensionsOfMatrix[1];
            matrix = new int[rows, cols];
            FillMatrix();

            Process();
            Console.WriteLine(collectedStars);
        }

        private static void Process()
        {
            string command;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                var IvoDimensions = SplitAndParseCommand(command);
                var evilPowerDimension = SplitAndParseInput();

                evilRow = evilPowerDimension[0];
                evilCol = evilPowerDimension[1];

                MoveEvil();

                IvoRow = IvoDimensions[0];
                IvoCol = IvoDimensions[1];

                MoveIvo();
            }
        }

        private static void MoveIvo()
        {
            while (IvoRow >= 0 && IvoCol < matrix.GetLength(1))
            {
                if (ValidateMove(IvoRow, IvoCol))
                {
                    collectedStars += matrix[IvoRow, IvoCol];
                }

                IvoRow--;
                IvoCol++;
            }
        }

        private static void MoveEvil()
        {
            while (evilRow >= 0 && evilCol >= 0)
            {
                if (ValidateMove(evilRow, evilCol))
                {
                    matrix[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }

        private static bool ValidateMove(int row, int col)
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

        static void PrintMatrix<T>(T[,] matrix)
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
        private static void FillMatrix()
        {
            var currNumber = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currNumber++;
                }
            }
        }
        private static int[] SplitAndParseInput()
        {
            return Console
                 .ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
        }

        private static int[] SplitAndParseCommand(string command)
        {
            return command
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
        }
    }
}
