namespace P01.TourDeSofia
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    internal class Edge
    {
        public int FromNode { get; set; }

        public int ToNode { get; set; }

        public int Distance { get; set; }
    }

    public class Program
    {
        private static List<Edge>[] graph;
        private static int destinationNode;

        public static void Main()
        {
            ReadInput();
            var result = FindShortestPathToDestination();
            Console.WriteLine(result);
        }

        private static double FindShortestPathToDestination()
        {
            var distance = new double[graph.Length];
            FillDestinationWithInitialValues(distance);

            var queue = new OrderedBag<int>(Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
            SetUpPriorityQueue(distance, queue);

            var countOfNodeReach = 1;
            while (queue.Any())
            {
                var currNode = queue.RemoveFirst();
                countOfNodeReach++;

                if (currNode == destinationNode) return distance[destinationNode];

                foreach (var edge in graph[currNode])
                {
                    if (double.IsPositiveInfinity(distance[edge.ToNode]))
                        queue.Add(edge.ToNode);

                    var newDistance = edge.Distance + distance[currNode];

                    if (newDistance < distance[edge.ToNode])
                    {
                        distance[edge.ToNode] = newDistance;
                        queue = new OrderedBag<int>(queue,
                            Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
                    }
                }
            }

            return countOfNodeReach;
        }

        private static void SetUpPriorityQueue(double[] distance, OrderedBag<int> queue)
        {
            foreach (var edge in graph[destinationNode])
            {
                distance[edge.ToNode] = edge.Distance;
                queue.Add(edge.ToNode);
            }
        }

        private static void FillDestinationWithInitialValues(double[] destination)
        {
            for (int node = 0; node < graph.Length; node++)
            {
                destination[node] = double.PositiveInfinity;
            }
        }

        private static void ReadInput()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var numberOfEdge = int.Parse(Console.ReadLine());
            destinationNode = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberOfNodes, numberOfEdge);
        }

        private static List<Edge>[] ReadGraph(int numberOfNodes, int numberOfEdge)
        {
            var output = new List<Edge>[numberOfNodes];

            for (int node = 0; node < numberOfNodes; node++)
            {
                output[node] = new List<Edge>();
            }

            for (int i = 0; i < numberOfEdge; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var fromNode = edgeArgs[0];
                var toNode = edgeArgs[1];
                var distance = edgeArgs[2];

                var edge = new Edge
                {
                    FromNode = fromNode,
                    ToNode = toNode,
                    Distance = distance
                };

                output[fromNode].Add(edge);
            }

            return output;
        }
    }
}
