namespace P03.ArticulationPoints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private const int FIRST_NODE = 0;
        private const int DEFAULT_DEPTH = 1;
        private static List<int>[] graph;
        private static List<int> articulatedPoints;
        private static bool[] visited;
        private static int[] previous;
        private static int[] lowpoint;
        private static int[] depth;
        static void Main()
        {
            ReadInput();
            SetInitialData();
            FindArticulationPoint(FIRST_NODE, DEFAULT_DEPTH);
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Articulation points: {string.Join(", ", articulatedPoints)}");
        }

        private static void SetInitialData()
        {
            articulatedPoints = new List<int>();
            visited = new bool[graph.Length];
            previous = new int[graph.Length];
            Array.Fill(previous, -1);
            depth = new int[graph.Length];
            lowpoint = new int[graph.Length];
        }

        private static void ReadInput()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var numberOfLines = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberOfNodes, numberOfLines);
        }

        private static List<int>[] ReadGraph(int numberOfNodes, int numberOfLines)
        {
            var graphOutput = new List<int>[numberOfNodes];
            for (int node = 0; node < numberOfNodes; node++)
            {
                graphOutput[node] = new List<int>();
            }

            for (int i = 0; i < numberOfLines; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var fromNode = edgeArgs[0];
                var children = edgeArgs.Skip(1);

                graphOutput[fromNode].AddRange(children);
            }

            return graphOutput;
        }

        private static void FindArticulationPoint(int node, int currDepth)
        {
            visited[node] = true;
            depth[node] = currDepth;
            lowpoint[node] = currDepth;

            var childCount = 0;
            var isArticulatedPoint = false;
            foreach (var neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    previous[neighbor] = node;
                    FindArticulationPoint(neighbor, currDepth + 1);
                    childCount++;

                    if (lowpoint[neighbor] >= depth[node])
                        isArticulatedPoint = true;

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[neighbor]);
                }
                else if (neighbor != previous[node])
                {
                    lowpoint[node] = Math.Min(lowpoint[node], depth[neighbor]);
                }
            }

            if (NodeIsArticulatedPoint(node, childCount, isArticulatedPoint))
            {
                articulatedPoints.Add(node);
            }
        }

        private static bool NodeIsArticulatedPoint(int node, int childCount, bool isArticulatedPoint)
        {
            return (previous[node] != -1 && isArticulatedPoint)
                ||(previous[node] == -1 && childCount > 1);
        }
    }
}
