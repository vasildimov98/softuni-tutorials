namespace P05.BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public Edge(string firstVetex, string secondVetex)
        {
            this.FirstVetex = firstVetex;
            this.SecondVetex = secondVetex;
        }

        public string FirstVetex { get; }
        public string SecondVetex { get; }
    }

    class Program
    {
        static void Main()
        {
            var graph = new Dictionary<string, List<string>>();

            var numberOfNodes = int.Parse(Console.ReadLine());
            var edges = new List<Edge>();
            ReadGraph(graph, edges, numberOfNodes);

            var sortedEdges = edges
                .OrderBy(e => e.FirstVetex)
                .ThenBy(e => e.SecondVetex)
                .ToList();

            RemoveEdges(graph, sortedEdges);
        }

        private static void RemoveEdges(Dictionary<string, List<string>> graph, List<Edge> edges)
        {
            var removedEdges = new List<Edge>();
            for (int i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];
                var firstVertex = edge.FirstVetex;
                var secondVertex = edge.SecondVetex;

                graph[firstVertex].Remove(secondVertex);
                graph[secondVertex].Remove(firstVertex);


                var edgeToRemove = removedEdges
                    .FirstOrDefault(e => e.SecondVetex == firstVertex
                    && e.FirstVetex == secondVertex);

                if (edgeToRemove != null) continue;
          

                if (HasPathFromTo(graph, firstVertex, secondVertex))
                    removedEdges.Add(edge);
                else
                {
                    graph[firstVertex].Add(secondVertex);
                    graph[secondVertex].Add(firstVertex);
                }
            }

            PrintResult(removedEdges);
        }

        private static void PrintResult(List<Edge> removedEdges)
        {
            Console.WriteLine($"Edges to remove: {removedEdges.Count}");
            foreach (var edge in removedEdges)
            {
                Console.WriteLine($"{edge.FirstVetex} - {edge.SecondVetex}");
            }
        }

        private static bool HasPathFromTo(Dictionary<string, List<string>> graph, string startVertex, string distanceVertex)
        {
            var queue = new Queue<string>();
            queue.Enqueue(startVertex);
            var visited = new HashSet<string> { startVertex};
            while (queue.Any())
            {
                var currVertex = queue.Dequeue();

                if (currVertex == distanceVertex) return true;

                foreach (var neighbor in graph[currVertex])
                {
                    if (visited.Contains(neighbor)) continue;
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }

            return false;
        }

        private static void ReadGraph(Dictionary<string, List<string>> graph, List<Edge> edges, int numberOfNodes)
        {
            for (int i = 0; i < numberOfNodes; i++)
            {
                var nodeArgs = Console
                    .ReadLine()
                    .Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.Trim())
                    .ToArray();

                var vertex = nodeArgs[0];
                var neighbors = nodeArgs.Skip(1).ToList();

                graph[vertex] = neighbors;

                foreach (var neighbor in graph[vertex])
                {
                    var edge = new Edge(vertex, neighbor);
                    edges.Add(edge);
                }
            }
        }
    }
}
