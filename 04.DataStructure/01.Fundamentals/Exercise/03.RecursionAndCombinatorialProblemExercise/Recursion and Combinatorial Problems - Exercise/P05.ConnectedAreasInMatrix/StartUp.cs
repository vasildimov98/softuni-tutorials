namespace P05.ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    class Area : IComparable<Area>
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }

        public int CompareTo(Area other)
        {
            var comp = other.Size.CompareTo(this.Size);

            if (comp == 0)
            {
                comp = this.Row.CompareTo(other.Row);
            }

            if (comp == 0)
            {
                comp = this.Col.CompareTo(other.Col);
            }

            return comp;
        }
    }

    class StartUp
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var matrix = new char[rows, cols];

            ReadMatrix(matrix, rows, cols);

            var areas = new List<Area>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (IsVisited(matrix, row, col)) continue;

                    if (IsWall(matrix, row, col)) continue;

                    var size = FindAreaSize(matrix, row, col);

                    var area = new Area { Row = row, Col = col, Size = size };

                    areas.Add(area);
                }
            }

            var sortedAreas = areas
                .OrderBy(a => a)
                .ToList();

            Console.WriteLine($"Total areas found: {areas.Count}");
            for (int i = 0; i < sortedAreas.Count; i++)
            {
                var area = sortedAreas[i];
                Console.WriteLine($"Area #{i + 1} at ({area.Row}, {area.Col}), size: {area.Size}");
            }
        }

        private static int FindAreaSize(char[,] matrix, int row, int col)
        {
            if (IsOutsideBorder(matrix, row, col)) return 0;
            if (IsWall(matrix, row, col)) return 0;
            if (IsVisited(matrix, row, col)) return 0;

            matrix[row, col] = 'v';

            var sizeOfUpperChild = FindAreaSize(matrix, row - 1, col);
            var sizeOfDownChild = FindAreaSize(matrix, row + 1, col);
            var sizeOfRightChild = FindAreaSize(matrix, row, col + 1);
            var sizeOfLeftChild = FindAreaSize(matrix, row, col - 1);

            var sizeOfArea = 1 + sizeOfUpperChild +
                sizeOfDownChild +
                sizeOfRightChild +
                sizeOfLeftChild;

            return sizeOfArea;
         }

        private static bool IsOutsideBorder(char[,] matrix, int row, int col)
        {
            return row < 0 ||
                row >= matrix.GetLength(0) ||
                col < 0 ||
                col >= matrix.GetLength(1);
        }

        private static bool IsWall(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsVisited(char[,] matrix, int row, int col)
        {
            return matrix[row, col] == 'v';
        }

        private static void ReadMatrix(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var colElements = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
        }
    }
}
