namespace P07.FindAllPathsInALabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static char[,] lab;
        private static List<char> path;
        static void Main()
        {
            path = new List<char>();
            lab = ReadLab();
            FindAllPathsInALabyrinth(0, 0, 'S');
        }

        private static void FindAllPathsInALabyrinth(int row, int col, char direction)
        {
            if (IsNotPossibleWay(row, col)) return;

            path.Add(direction);

            if (IsExit(row, col))
            {
                PrintPaths();
                path.RemoveAt(path.Count - 1);
                return;
            }

            MarkPath(row, col);

            GoToAllPossibleDirection(row, col);

            UnmarkPath(row, col);

            path.RemoveAt(path.Count - 1);
        }

        private static void GoToAllPossibleDirection(int row, int col)
        {
            FindAllPathsInALabyrinth(row, col + 1, 'R');
            FindAllPathsInALabyrinth(row + 1, col, 'D');
            FindAllPathsInALabyrinth(row, col - 1, 'L');
            FindAllPathsInALabyrinth(row - 1, col, 'U');
        }

        private static void UnmarkPath(int row, int col)
        {
            lab[row, col] = '-';
        }

        private static void MarkPath(int row, int col)
        {
            lab[row, col] = 'v';
        }

        private static void PrintPaths()
        {
            Console.WriteLine(string.Join("", path.Skip(1)));
        }

        private static bool IsExit(int row, int col)
        {
            return lab[row, col] == 'e';
        }

        private static bool IsNotPossibleWay(int row, int col)
        {
            return IsOutsideOfBorder(row, col)
                || IsWall(row, col)
                || IsVisited(row, col);
        }

        private static bool IsVisited(int row, int col)
        {
            return lab[row, col] == 'v';
        }

        private static bool IsWall(int row, int col)
        {
            return lab[row, col] == '*';
        }

        private static bool IsOutsideOfBorder(int row, int col)
        {
            return row < 0
                || row >= lab.GetLength(0)
                || col < 0
                || col >= lab.GetLength(1);
        }

        private static char[,] ReadLab()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var line = Console.ReadLine();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            return matrix;
        }
    }
}
