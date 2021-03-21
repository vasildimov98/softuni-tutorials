namespace P01.Bellman_Ford
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
        private static int nodes;
        private static int startNode;
        private static int endNode;
        private static List<Edge> edges;
        private static double[] destination;
        private static int[] previous;

        static void Main()
        {
            ReadInput();
            try
            {
                FindLongestPath();
                var shortestPath = ReconstructPath();
                PrintPath(shortestPath); 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintPath(Stack<int> shortestPath)
        {
            Console.WriteLine(string.Join(" ", shortestPath));
            Console.WriteLine(destination[endNode]);
        }

        private static Stack<int> ReconstructPath()
        {
            var result = new Stack<int>();
            var currNode = endNode;
            while (currNode != -1)
            {
                result.Push(currNode);
                currNode = previous[currNode];
            }

            return result;
        }

        private static void FindLongestPath()
        {
            destination[startNode] = 0;
            for (int i = 0; i < nodes - 1; i++)
            {
                var isShortestPathFound = true;
                foreach (var edge in edges)
                {
                    if (double.IsPositiveInfinity(destination[edge.FromNode])) continue;

                    var newDestination = edge.Weight + destination[edge.FromNode];

                    if (newDestination < destination[edge.ToNode])
                    {
                        isShortestPathFound = false;
                        destination[edge.ToNode] = newDestination;
                        previous[edge.ToNode] = edge.FromNode;
                    }
                }

                if (isShortestPathFound) break;
            }

            foreach (var edge in edges)
            {
                if (double.IsPositiveInfinity(destination[edge.FromNode])) continue;

                var newDestination = edge.Weight + destination[edge.FromNode];

                if (newDestination < destination[edge.ToNode])
                {
                    throw new InvalidOperationException("Negative Cycle Detected");
                }
            }
        }

        private static void ReadInput()
        {
            nodes = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            edges = new List<Edge>();
            destination = Enumerable.Repeat(double.PositiveInfinity, nodes + 1).ToArray();
            previous = Enumerable.Repeat(-1, nodes + 1).ToArray();

            ReadEdges(edgesCount);
            startNode = int.Parse(Console.ReadLine());
            endNode = int.Parse(Console.ReadLine());
        }

        private static void ReadEdges(int edgesCount)
        {
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

                var edge = new Edge(fromNode, toNode, weight);

                edges.Add(edge);
            }
        }
    }

}
