namespace P04.BigTrip
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Edge
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
        private static List<Edge>[] graph;
        private static int startNode;
        private static int endNode;
        private static double[] distance;
        private static int[] previous;

        static void Main()
        {
            ReadInput();
            distance = CalculateLongestPath();
            PrintResult();
        }

        private static void PrintResult()
        {
            var path = ReconstructPath();
            Console.WriteLine(distance[endNode]);
            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<int> ReconstructPath()
        {
            var outputPath = new Stack<int>();

            var currNode = endNode;

            while (currNode != -1)
            {
                outputPath.Push(currNode);
                currNode = previous[currNode];
            }

            return outputPath;
        }

        private static double[] CalculateLongestPath()
        {
            var distance = Enumerable.Repeat(double.NegativeInfinity, graph.Length).ToArray();
            previous = Enumerable.Repeat(-1, graph.Length).ToArray();

            var sortedNodes = TopologicalSort();

            distance[startNode] = 0;

            foreach (var node in sortedNodes)
            {
                foreach (var edge in graph[node])
                {
                    var newDistance = edge.Weight + distance[edge.FromNode];

                    if (newDistance > distance[edge.ToNode])
                    {
                        previous[edge.ToNode] = edge.FromNode;
                        distance[edge.ToNode] = newDistance;
                    }
                }
            }

            return distance;
        }

        private static Stack<int> TopologicalSort()
        {
            var output = new Stack<int>();
            var visited = new bool[graph.Length];

            for (int node = 1; node < graph.Length; node++)
            {
                if (visited[node]) continue;

                DFS(node, visited, output);
            }

            return output;
        }

        private static void DFS(int node, bool[] visited, Stack<int> nodes)
        {
            if (visited[node]) return;

            visited[node] = true;

            foreach (var neighbor in graph[node])
            {
                DFS(neighbor.ToNode, visited, nodes);
            }

            nodes.Push(node);
        }

        private static void ReadInput()
        {
            var numberOfNodes = int.Parse(Console.ReadLine()) + 1;
            var numberOfEdges = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberOfNodes, numberOfEdges);
            startNode = int.Parse(Console.ReadLine());
            endNode = int.Parse(Console.ReadLine());
        }

        private static List<Edge>[] ReadGraph(int numberOfNodes, int numberOfEdges)
        {
            var resultGraph = new List<Edge>[numberOfNodes];

            for (int node = 1; node < resultGraph.Length; node++)
            {
                resultGraph[node] = new List<Edge>();
            }

            for (int i = 0; i < numberOfEdges; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var fromNode = edgeArgs[0];
                var toNode = edgeArgs[1];
                var weigh = edgeArgs[2];

                var edge = new Edge(fromNode, toNode, weigh);

                resultGraph[fromNode].Add(edge);
            }

            return resultGraph;
        }
    }
}