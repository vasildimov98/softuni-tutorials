namespace P01.TBC
{
    using System;
    class Program
    {
        private const char DIRT = 'd';

        private static char[,] map;
        private static bool[,] visited;
        private static int connectedTunelCount;
        static void Main()
        {
            map = ReadMatrix();

            CountTheConnectedTunel();

            Console.WriteLine(connectedTunelCount);
        }

        private static void CountTheConnectedTunel()
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (IsVisited(row, col)) continue;

                    if (IsDirt(row, col)) continue;

                    var countOfConnectedTunnels = FindCountOfConnectedTunnels(row, col);

                    if (countOfConnectedTunnels > 1) connectedTunelCount++;
                }
            }
        }

        private static int FindCountOfConnectedTunnels(int row, int col)
        {
            if (IsOutSideTheBoundOfTheMatrix(row, col)) return 0;
            if (IsDirt(row, col)) return 0;
            if (IsVisited(row, col)) return 0;

            visited[row, col] = true;

            return 1 + FindCountOfConnectedTunnels(row, col + 1)
                + FindCountOfConnectedTunnels(row + 1, col + 1)
                + FindCountOfConnectedTunnels(row + 1, col)
                + FindCountOfConnectedTunnels(row + 1, col - 1)
                + FindCountOfConnectedTunnels(row, col - 1)
                + FindCountOfConnectedTunnels(row - 1, col - 1)
                + FindCountOfConnectedTunnels(row - 1, col)
                + FindCountOfConnectedTunnels(row - 1, col + 1);
        }

        private static bool IsOutSideTheBoundOfTheMatrix(int row, int col)
        {
            return row < 0
                || row >= map.GetLength(0)
                || col < 0
                || col >= map.GetLength(1);
        }

        private static bool IsDirt(int row, int col)
        {
            return map[row, col] == DIRT;
        }

        private static bool IsVisited(int row, int col)
        {
            return visited[row, col];
        }


        private static char[,] ReadMatrix()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new char[rows, cols];
            visited = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var colsInput = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colsInput[col];
                }
            }

            return matrix;
        }
    }
}
