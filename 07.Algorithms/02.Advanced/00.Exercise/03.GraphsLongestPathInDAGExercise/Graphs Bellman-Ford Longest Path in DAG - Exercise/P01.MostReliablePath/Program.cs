namespace P01.MostReliablePath
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    class Edge
    {
        public Edge(int firstNode, int secondNode, double coefficient)
        {
            this.FirstNode = firstNode;
            this.SecondNode = secondNode;
            this.Coefficient = coefficient;
        }

        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public double Coefficient { get; set; }
    }

    class Program
    {
        private static List<Edge>[] edges;
        private static int startNode;
        private static int endNode;
        static void Main()
        {
            ReadInput();
            FindMostRealiblePath();
        }

        private static void FindMostRealiblePath()
        {
            var distance = Enumerable.Repeat(double.NegativeInfinity, edges.Length).ToArray();
            var previous = Enumerable.Repeat(-1, edges.Length).ToArray();

            distance[startNode] = 100;

            var sortedNodesByDistance = new OrderedBag<int>(Comparer<int>.Create((f, s) => distance[s].CompareTo(distance[f])));

            sortedNodesByDistance.Add(startNode);
            FindPath(distance, previous, sortedNodesByDistance);
            PrintMostReliablePath(distance, previous);
        }

        private static void PrintMostReliablePath(double[] distance, int[] previous)
        {
            Console.WriteLine($"Most reliable path reliability: {distance[endNode]:F2}%");
            var mostReliablePath = ReconstructPath(previous);
            Console.WriteLine(string.Join(" -> ", mostReliablePath));
        }

        private static Stack<int> ReconstructPath(int[] previous)
        {
            var path = new Stack<int>();

            var currNode = endNode;
            while (currNode != -1)
            {
                path.Push(currNode);
                currNode = previous[currNode];
            }

            return path;
        }

        private static void FindPath(double[] distance, int[] previous, OrderedBag<int> sortedNodesByDistance)
        {
            while (sortedNodesByDistance.Any())
            {
                var currNode = sortedNodesByDistance.RemoveFirst();

                if (double.IsNegativeInfinity(distance[currNode]))
                {
                    break;
                }

                var neighborNodes = edges[currNode];

                foreach (var edge in neighborNodes)
                {
                    var neighborNode = edge.FirstNode == currNode ? edge.SecondNode : edge.FirstNode;

                    if (double.IsNegativeInfinity(distance[neighborNode]))
                    {
                        sortedNodesByDistance.Add(neighborNode);
                    }

                    var newDistance = (edge.Coefficient * distance[currNode]) / 100;

                    if (newDistance > distance[neighborNode])
                    {
                        distance[neighborNode] = newDistance;
                        previous[neighborNode] = currNode;
                        sortedNodesByDistance.Remove(neighborNode);
                        sortedNodesByDistance.Add(neighborNode);
                    }
                }
            }
        }

        private static void ReadInput()
        {
            var countOfNodes = int.Parse(Console.ReadLine());
            var countOfEdges = int.Parse(Console.ReadLine());
            edges = ReadEdges(countOfNodes, countOfEdges);
            startNode = int.Parse(Console.ReadLine());
            endNode = int.Parse(Console.ReadLine());
        }

        private static List<Edge>[] ReadEdges(int countOfNodes, int countOfEdges)
        {
            var result = new List<Edge>[countOfNodes];

            for (int node = 0; node < result.Length; node++)
            {
                result[node] = new List<Edge>();
            }

            for (int i = 0; i < countOfEdges; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeArgs[0];
                var secondNode = edgeArgs[1];
                var coefficient = (double)edgeArgs[2];

                var edge = new Edge(firstNode, secondNode, coefficient);

                result[firstNode].Add(edge);
                result[secondNode].Add(edge);
            }

            return result;
        }
    }
}
