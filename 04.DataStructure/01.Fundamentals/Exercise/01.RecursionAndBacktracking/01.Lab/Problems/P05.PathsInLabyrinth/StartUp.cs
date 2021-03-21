namespace P05.PathsInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            var labyrinth = new char[row, col];
            FillMatrix(labyrinth);

            FindAllPossiblePaths(labyrinth, 0, 0, new List<char>());
        }

        private static void FindAllPossiblePaths(char[,] matrix, int currRow, int currCol, List<char> directions, char direction = '\0')
        {
            if (IsCellInvalid(matrix, currRow, currCol)) return;

            directions.Add(direction);

            if (IsCellTheFinalDestination(matrix, currRow, currCol))
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            matrix[currRow, currCol] = 'v';

            FindAllPossiblePaths(matrix, currRow, currCol + 1, directions, 'R');
            FindAllPossiblePaths(matrix, currRow + 1, currCol, directions, 'D');
            FindAllPossiblePaths(matrix, currRow - 1, currCol, directions, 'U');
            FindAllPossiblePaths(matrix, currRow, currCol - 1, directions, 'L');

            directions.RemoveAt(directions.Count - 1);
            matrix[currRow, currCol] = '-';
        }

        private static bool IsCellTheFinalDestination(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == 'e';
        }

        private static bool IsCellInvalid(char[,] matrix, int row, int col)
        {
            return IsOutOfBorder(matrix, row, col)
                || IsWall(matrix, row, col)
                || IsCellAlreadyVisited(matrix, row, col);
        }

        private static bool IsCellAlreadyVisited(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == 'v';
        }

        private static bool IsWall(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutOfBorder(char[,] matrix, int row, int col)
        {
            return row < 0 ||
                row >= matrix.GetLength(0) ||
                col < 0 ||
                col >= matrix.GetLength(1);
        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var parameters = Console.ReadLine();
                for (int col = 0; col < parameters.Length; col++)
                {
                    matrix[row, col] = parameters[col];
                }
            }
        }
    }
}
