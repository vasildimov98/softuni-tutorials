namespace P06.ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    class Program
    {
        private const char WALL = '*';
        private const char VISITED = 'v';

        private static char[,] matrix;
        private readonly static SortedSet<Area> areas = new SortedSet<Area>();

        static void Main()
        {
            matrix = ReadMatrix();

            FindAllAreas(matrix);

            PrintAreasInfo(areas);
        }

        private static void PrintAreasInfo(SortedSet<Area> areas)
        {
            Console.WriteLine($"Total areas found: {areas.Count}");

            var count = 1;
            foreach (var area in areas)
            {
                Console.WriteLine($"Area #{count++} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static void FindAllAreas(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (CellIsInvalid(row, col)) continue;

                    var area = new Area(row, col)
                    {
                        Size = FindAreaSize(row, col)
                    };

                    areas.Add(area);
                }
            }
        }

        private static int FindAreaSize(int row, int col)
        {
            if (CellIsInvalid(row, col)) return 0;

            matrix[row, col] = VISITED;

            return 1
                + FindAreaSize(row, col + 1)
                + FindAreaSize(row + 1, col)
                + FindAreaSize(row, col - 1)
                + FindAreaSize(row - 1, col);
        }

        private static bool CellIsInvalid(int row, int col)
        {
            return IsOutSideOfMatrix(row, col)
                || IsVisited(row, col)
                || IsWall(row, col);
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == VISITED;
        }

        private static bool IsOutSideOfMatrix(int row, int col)
        {
            return row < 0
                || row >= matrix.GetLength(0)
                || col < 0
                || col >= matrix.GetLength(1);
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == WALL;
        }

        private static char[,] ReadMatrix()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currCol = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currCol[col];
                }
            }

            return matrix;
        }
    }

    internal class Area : IComparable<Area>
    {
        public Area(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Size { get; set; }

        public int Row { get; set; }
        public int Col { get; set; }

        public int CompareTo(Area other)
        {
            var compare = other.Size.CompareTo(this.Size);

            if (compare == 0)
                compare = this.Row.CompareTo(other.Row);

            if (compare == 0)
                compare = this.Col.CompareTo(other.Col);

            return compare;
        }
    }
}
