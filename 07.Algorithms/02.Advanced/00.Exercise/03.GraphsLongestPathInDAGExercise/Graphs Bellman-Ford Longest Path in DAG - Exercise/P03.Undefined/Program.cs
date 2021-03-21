namespace P03.Undefined
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
        private static int nodes;
        private static List<Edge> edges;
        private static int startNode;
        private static int endNode;
        private static double[] distance;
        private static int[] previous;

        static void Main()
        {
            ReadInput();
            try
            {
                distance = FindDistanceBetweenNodes();
                PrintResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintResult()
        {
            var path = ReconstructPath();
            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[endNode]);
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

        private static double[] FindDistanceBetweenNodes()
        {
            var distance = Enumerable.Repeat(double.PositiveInfinity, nodes + 1).ToArray();
            previous = Enumerable.Repeat(-1, nodes + 1).ToArray();

            distance[startNode] = 0;

            for (int i = 0; i < nodes - 1; i++)
            {
                var isUpdated = true;
                foreach (var edge in edges)
                {
                    if (double.IsPositiveInfinity(edge.FromNode))
                    {
                        continue;
                    }

                    var newDistance = edge.Weight + distance[edge.FromNode];

                    if (newDistance < distance[edge.ToNode])
                    {
                        isUpdated = false;
                        distance[edge.ToNode] = newDistance;
                        previous[edge.ToNode] = edge.FromNode;
                    }
                }

                if (isUpdated) break;
            }

            foreach (var edge in edges)
            {
                var newDistance = edge.Weight + distance[edge.FromNode];

                if (newDistance < distance[edge.ToNode])
                {
                    throw new InvalidOperationException("Undefined");
                }
            }

            return distance;
        }

        private static void ReadInput()
        {
            nodes = int.Parse(Console.ReadLine());
            var edgesCount = int.Parse(Console.ReadLine());

            edges = ReadEdges(edgesCount);

            startNode = int.Parse(Console.ReadLine());
            endNode = int.Parse(Console.ReadLine());
        }

        private static List<Edge> ReadEdges(int edges)
        {
            var result = new List<Edge>();

            for (int i = 0; i < edges; i++)
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

                result.Add(edge);
            }

            return result;
        }
    }
}
