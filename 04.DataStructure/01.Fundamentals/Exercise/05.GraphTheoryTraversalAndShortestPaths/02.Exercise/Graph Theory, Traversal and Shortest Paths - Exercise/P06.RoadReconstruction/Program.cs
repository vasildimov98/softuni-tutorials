namespace P06.RoadReconstruction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var graph = new Dictionary<int, List<int>>();
            var edges = new List<Edge>();

            var numberOfBuildings = int.Parse(Console.ReadLine());
            for (int node = 0; node < numberOfBuildings; node++)
                graph[node] = new List<int>();

            ReadGraph(graph, edges);

            var importantRoads = new List<Edge>();
            foreach (var edge in edges)
            {
                var firstVertex = edge.FirstBuilding;
                var secondVertex = edge.SecondBuilding;

                graph[firstVertex].Remove(secondVertex);
                graph[secondVertex].Remove(firstVertex);


                if (BFS(graph, firstVertex))
                {
                    importantRoads.Add(edge);
                }

                graph[firstVertex].Add(secondVertex);
                graph[secondVertex].Add(firstVertex);
            }

            Console.WriteLine("Important streets:");
            importantRoads
                .ForEach(s => Console.WriteLine($"{s.FirstBuilding} {s.SecondBuilding}"));
        }

        private static bool BFS(Dictionary<int, List<int>> graph, int startNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            var visited = new HashSet<int> { startNode };

            while (queue.Count > 0)
            {
                var currVertex = queue.Dequeue();

                foreach (var neighbor in graph[currVertex])
                {
                    if (visited.Contains(neighbor)) continue;
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }

            if (visited.Count == graph.Count) return false;
            else return true;
        }

        private static void ReadGraph(Dictionary<int, List<int>> graph, List<Edge> edges)
        {
            var amountOfStreets = int.Parse(Console.ReadLine());
            for (int i = 0; i < amountOfStreets; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                var vertex = args[0];
                var neighbor = args[1];

                graph[vertex].Add(neighbor);
                graph[neighbor].Add(vertex);

                edges.Add(new Edge(vertex, neighbor));
            }
        }
    }

    internal class Edge
    {
        public Edge(int firstVertex, int secondVertex)
        {
            this.FirstBuilding = Math.Min(firstVertex, secondVertex);
            this.SecondBuilding = Math.Max(firstVertex, secondVertex);
        }

        public int FirstBuilding { get; }
        public int SecondBuilding { get; }
    }
}
