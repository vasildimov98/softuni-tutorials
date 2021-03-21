namespace P02.EmergencyPlan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    internal class Edge
    {
        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public TimeSpan Time { get; set; }
    }

    public class Program
    {
        private static readonly TimeSpan MAX_TIME_SPAM = new TimeSpan(23,59,59);

        private static List<Edge>[] graph;
        private static int[] exists;
        private static TimeSpan saveTime;
        public static void Main()
        {
            ReadInput();
            FindMinimumShortestPath();
        }

        private static void FindMinimumShortestPath()
        {
            for (int node = 0; node < graph.Length; node++)
            {
                if (exists.Contains(node)) continue;

                var distance = InitializeDistance();
                var visited = new bool[graph.Length];

                Dijkstra(node, distance, visited);

                var minTimeSpam = distance[exists[0]];

                for (int i = 1; i < exists.Length; i++)
                {
                    if (distance[exists[i]] < minTimeSpam)
                    {
                        minTimeSpam = distance[exists[i]];
                    }
                }

                if (minTimeSpam == MAX_TIME_SPAM)
                {
                    Console.WriteLine($"Unreachable {node} (N/A)");
                }
                else if (minTimeSpam <= saveTime)
                {
                    Console.WriteLine($"Safe {node} ({minTimeSpam})");
                }
                else
                {
                    Console.WriteLine($"Unsafe {node} ({minTimeSpam})");
                }
            }
        }

        private static TimeSpan[] InitializeDistance()
        {
            var distance = new TimeSpan[graph.Length];

            for (int node = 0; node < graph.Length; node++)
            {
                distance[node] = new TimeSpan(23, 59, 59);
            }

            return distance;
        }

        private static void Dijkstra(int node, TimeSpan[] distance, bool[] visited)
        {
            var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])))
            {
                node
            };

            distance[node] = new TimeSpan(0, 0, 0);
            visited[node] = true;

            while (priorityQueue.Any())
            {
                var minNode = priorityQueue.RemoveFirst();

                if (distance[minNode] == MAX_TIME_SPAM) break;

                foreach (var child in graph[minNode])
                {
                    var otherNode = child.FirstNode == minNode ?
                        child.SecondNode : child.FirstNode;

                    if (!visited[otherNode])
                    {
                        priorityQueue.Add(otherNode);
                        visited[otherNode] = true;
                    }

                    var newDistance = distance[minNode].Add(child.Time);

                    if (newDistance.CompareTo(distance[otherNode]) < 0)
                    {
                        distance[otherNode] = newDistance;
                        priorityQueue = new OrderedBag<int>(priorityQueue,
                            Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
                    }
                }
            }
        }

        private static void ReadInput()
        {
            var nodes = int.Parse(Console.ReadLine());

            exists = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var edges = int.Parse(Console.ReadLine());

            graph = ReadEdge(nodes, edges);

            var saveTimeArgs = Console.ReadLine().Split(':').Select(int.Parse).ToArray();

            saveTime = new TimeSpan(0, saveTimeArgs[0], saveTimeArgs[1]);
        }

        private static List<Edge>[] ReadEdge(int nodes, int edges)
        {
            var output = new List<Edge>[nodes];

            for (int node = 0; node < nodes; node++)
            {
                output[node] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split()
                    .ToArray();

                var firstNode = int.Parse(args[0]);
                var secondNode = int.Parse(args[1]);


                var timeArgs = args[2].Split(':').Select(int.Parse).ToArray();

                var time = new TimeSpan(0, timeArgs[0], timeArgs[1]);

                var edge = new Edge
                {
                    FirstNode = firstNode,
                    SecondNode = secondNode,
                    Time = time
                };

                output[firstNode].Add(edge);
                output[secondNode].Add(edge);
            }

            return output;
        }
    }
}
