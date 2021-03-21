namespace P03.ShortestPath
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<int, List<int>> graph;
        private static Dictionary<int, int> predecessors;
        private static HashSet<int> visited;
        public static void Main()
        {
            graph = new Dictionary<int, List<int>>();
            predecessors = new Dictionary<int, int>();
            visited = new HashSet<int>();

            var numberOfNodes = int.Parse(Console.ReadLine());

            for (int node = 1; node <= numberOfNodes; node++)
            {
                graph[node] = new List<int>();
                predecessors[node] = -1;
            }
            

            var numberOfEdges = int.Parse(Console.ReadLine());

            CreateGraph(numberOfEdges);
            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());

            FindTheShortestPath(startNode, endNode);
        }

        private static void FindTheShortestPath(int startNode, int endNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited.Add(startNode);
            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();

                if (currNode == endNode)
                {
                    var path = new Stack<int>();
                    TrackPathBackwards(path, endNode);
                    PrintPath(path);
                    return;
                }

                foreach (var neighbor in graph[currNode])
                {
                    if (visited.Contains(neighbor)) continue;
                    queue.Enqueue(neighbor);
                    predecessors[neighbor] = currNode;
                    visited.Add(neighbor);
                }

            }
        }

        private static void PrintPath(Stack<int> path)
        {
            Console.WriteLine($"Shortest path length is: {path.Count - 1}");
            Console.WriteLine(string.Join(" ", path));
        }

        private static void TrackPathBackwards(Stack<int> path, int endNode)
        {
            path.Push(endNode);
            var currNode = predecessors[endNode];
            while (currNode != -1)
            {
                path.Push(currNode);
                currNode = predecessors[currNode];
            }
        }

        private static void CreateGraph(int edges)
        {
            for (int i = 0; i < edges; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var vertex = args[0];
                var neighbor = args[1];

                graph[vertex].Add(neighbor);
            }
        }
    }
}
