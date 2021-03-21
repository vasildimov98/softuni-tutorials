namespace P02.LongestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Edge
    {
        public Edge(int fromNode, int toNode, int weight)
        {
            this.FromNode = fromNode;
            this.ToNode = toNode;
            this.Weight = weight;
        }

        public int FromNode { get; set; }
        public int ToNode { get; set; }
        public int Weight { get; set; }
    }

    class Program
    {
        private static Dictionary<int, List<Edge>> graph;
        private static double[] distance;
        private static int[] previous;
        private static int sourceNode;
        private static int destinationNode;
        static void Main()
        {
            ReadInput();
            FindLongestPathInGraph();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(distance[destinationNode]);
        }

        private static void FindLongestPathInGraph()
        {
            var topologicalSortedNodes = TopologicalSort();
            distance[sourceNode] = 0;
            foreach (var node in topologicalSortedNodes)
            {
                foreach (var edge in graph[node])
                {
                    var newDistance = distance[node] + edge.Weight;

                    if (newDistance > distance[edge.ToNode])
                    {
                        distance[edge.ToNode] = newDistance;
                        previous[edge.ToNode] = node;
                    }
                }
            }
        }

        private static Stack<int> TopologicalSort()
        {
            var resultSort = new Stack<int>();
            var visited = new bool[graph.Count + 1];
            foreach (var node in graph.Keys)
            {
                if (visited[node]) continue;

                DFS(node, visited, resultSort);
            }

            return resultSort;
        }

        private static void DFS(int currNode, bool[] visited, Stack<int> resultSort)
        {
            if (visited[currNode]) return;
            visited[currNode] = true;

            foreach (var neighbor in graph[currNode])
            {
                DFS(neighbor.ToNode, visited, resultSort);
            }

            resultSort.Push(currNode);
        }

        private static void ReadInput()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            graph = ReadGraph();
            sourceNode = int.Parse(Console.ReadLine());
            destinationNode = int.Parse(Console.ReadLine());
            distance = SetInitialDistanceToNodes(nodesCount);
            previous = SetInitialPreviousToNodes(nodesCount);
        }

        private static int[] SetInitialPreviousToNodes(int nodesCount)
        {
            return Enumerable.Repeat(-1, nodesCount + 1).ToArray();
        }

        private static double[] SetInitialDistanceToNodes(int nodesCount)
        {
            return Enumerable.Repeat(double.NegativeInfinity, nodesCount + 1).ToArray();
        }

        private static Dictionary<int, List<Edge>> ReadGraph()
        {
            var edgesCount = int.Parse(Console.ReadLine());

            var graphResult = new Dictionary<int, List<Edge>>();
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var fromNode = edgeArgs[0];
                var toNode = edgeArgs[1];
                var weight = edgeArgs[2];

                if (!graphResult.ContainsKey(fromNode))
                    graphResult[fromNode] = new List<Edge>();

                if (!graphResult.ContainsKey(toNode))
                    graphResult[toNode] = new List<Edge>();

                var edge = new Edge(fromNode, toNode, weight);

                graphResult[fromNode].Add(edge);
            }

            return graphResult;
        }
    }
}
