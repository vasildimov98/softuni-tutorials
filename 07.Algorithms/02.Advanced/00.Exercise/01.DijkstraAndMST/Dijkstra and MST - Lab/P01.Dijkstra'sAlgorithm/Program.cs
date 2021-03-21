namespace P01.Dijkstra_sAlgorithm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    class Edge
    {
        public Edge(int firstNode, int secondNode, int distance)
        {
            this.FirstNode = firstNode;
            this.SecondNode = secondNode;
            this.Distance = distance;
        }

        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public int Distance { get; set; }
    }

    class Program
    {
        private static Dictionary<int, List<Edge>> graph;
        private static int[] distance;
        private static int[] previous;
        private static int startNode;
        private static int endNode;
        private static Stack<int> shortestPath;
        static void Main()
        {
            ReadInput();
            FindDistanceBetweenTwoNodes();
            PrintResult();
        }

        private static void PrintResult()
        {
            if (distance[endNode] == int.MaxValue)
                Console.WriteLine("There is no such path.");
            else
            {
                Console.WriteLine(distance[endNode]);
                shortestPath = BackTrackPath();
                Console.WriteLine(string.Join(" ", shortestPath));
            }
        }

        private static Stack<int> BackTrackPath()
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

        private static void FindDistanceBetweenTwoNodes()
        {
            distance[startNode] = 0;
            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => distance[f] - distance[s]));
            priorityQueue.Add(startNode);

            while (priorityQueue.Count > 0)
            {
                var minNode = priorityQueue.RemoveFirst();

                if (distance[minNode] == int.MaxValue
                    || minNode == endNode) break;

                foreach (var neighbor in graph[minNode])
                {
                    var neighborNode = neighbor.FirstNode == minNode ?
                        neighbor.SecondNode :
                        neighbor.FirstNode;

                    if (distance[neighborNode] == int.MaxValue)
                        priorityQueue.Add(neighborNode);

                    var newDistanceToCurrNode = neighbor.Distance
                        + distance[minNode];

                    if (newDistanceToCurrNode < distance[neighborNode])
                    {
                        previous[neighborNode] = minNode;
                        distance[neighborNode] = newDistanceToCurrNode;
                        priorityQueue.Remove(neighborNode);
                        priorityQueue.Add(neighborNode);
                    }
                }
            }
        }

        private static void ReadInput()
        {
            graph = ReadGraph();
            distance = ReadDistance();
            previous = ReadPrevious();
            startNode = int.Parse(Console.ReadLine());
            endNode = int.Parse(Console.ReadLine());
        }

        private static int[] ReadPrevious()
            => Enumerable.Repeat(-1, graph.Count + 1).ToArray();

        private static int[] ReadDistance()
            => Enumerable.Repeat(int.MaxValue, graph.Count + 1).ToArray();

        private static Dictionary<int, List<Edge>> ReadGraph()
        {
            var result = new Dictionary<int, List<Edge>>();

            var edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var first = edgeArgs[0];
                var second = edgeArgs[1];
                var weight = edgeArgs[2];

                if (!result.ContainsKey(first))
                    result[first] = new List<Edge>();
                if (!result.ContainsKey(second))
                    result[second] = new List<Edge>();

                var edge = new Edge(first, second, weight);

                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }
    }
}
