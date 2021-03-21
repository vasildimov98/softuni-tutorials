namespace P02.AreasInMatrix
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var matrix = new char[rows, cols];
            ReadMatix(matrix);
            FindAllAreas(matrix);
        }

        private static void FindAllAreas(char[,] matrix)
        {
            var visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            var areasCount = 0;
            var areaByCount = new SortedDictionary<char, int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (visited[row, col]) continue;

                    DFS(matrix, visited, row, col);
                    areasCount++;
                    var area = matrix[row, col];

                    if (!areaByCount.ContainsKey(area))
                        areaByCount[area] = 0;

                    areaByCount[area]++;
                }
            }

            Console.WriteLine($"Areas: {areasCount}");
            foreach (var area in areaByCount)
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
        }

        private static void DFS(char[,] matrix, bool[,] visited, int row, int col)
        {
            visited[row, col] = true;
            var neighbors = GetNeighbors(matrix, visited, row, col);

            foreach (var neighbor in neighbors)
                DFS(matrix, visited, neighbor.Row, neighbor.Col);
        }

        private static List<Neighbor> GetNeighbors(char[,] matrix, bool[,] visited,  int row, int col)
        {
            var neighbors = new List<Neighbor>();
            // row - 1, col
            if (IsValid(matrix, visited, row, col, row - 1, col))
                neighbors.Add(new Neighbor(row - 1, col));
            // row + 1, col
            if (IsValid(matrix, visited, row, col, row + 1, col))
                neighbors.Add(new Neighbor(row + 1, col));
            // row, col - 1
            if (IsValid(matrix, visited, row, col, row, col - 1))
                neighbors.Add(new Neighbor(row, col - 1));
            // row, col + 1
            if (IsValid(matrix, visited, row, col, row, col + 1))
                neighbors.Add(new Neighbor(row, col + 1));

            return neighbors;
        }

        private static bool IsValid(char[,] matrix, bool[,] visited, int parentRow, int parentCol, int childRow, int childCol)
        {
            return IsOutOfBorders(matrix, childRow, childCol)
                && IsNotVisited(visited, childRow, childCol)
                && IsTheSameLetter(matrix, parentRow, parentCol, childRow, childCol);
        }

        private static bool IsNotVisited(bool[,] visited, int childRow, int childCol)
        {
            return !visited[childRow, childCol];
        }

        private static bool IsTheSameLetter(char[,] matrix, int parentRow, int parentCol, int childRow, int childCol)
        {
            return matrix[parentRow, parentCol] == matrix[childRow, childCol];
        }

        private static bool IsOutOfBorders(char[,] matrix, int row, int col)
        {
            return row >= 0
                && row < matrix.GetLength(0)
                && col >= 0
                && col < matrix.GetLength(1);
        }

        private static void ReadMatix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var cols = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = cols[col];
                }
            }
        }
    }

    internal class Neighbor
    {
        public Neighbor(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; }
        public int Col { get; }
    }
}
