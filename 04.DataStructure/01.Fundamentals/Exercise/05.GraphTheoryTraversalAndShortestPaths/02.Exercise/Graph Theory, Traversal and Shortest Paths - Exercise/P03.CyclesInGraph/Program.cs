namespace P03.CyclesInGraph
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var graph = new Dictionary<string, List<string>>();
            ReadGraph(graph);
            var visited = new HashSet<string>();
            foreach (var vertex in graph.Keys)
            {
                if (visited.Contains(vertex)) continue;
                var cycles = new HashSet<string>();

                try
                {
                    DFS(graph, visited, cycles, vertex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            Console.WriteLine("Acyclic: Yes");
        }

        private static void DFS(Dictionary<string, List<string>> graph,
            HashSet<string> visited,
            HashSet<string> cycles,
            string vertex)
        {
            if (cycles.Contains(vertex))
                throw new ArgumentException("Acyclic: No");

            cycles.Add(vertex);

            if (visited.Contains(vertex)) return;

            visited.Add(vertex);

            foreach (var neighbor in graph[vertex])
                DFS(graph, visited, cycles, neighbor);

            cycles.Remove(vertex);
        }

        private static void ReadGraph(Dictionary<string, List<string>> graph)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var args = input
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var vertex = args[0];
                var neighbor = args[1];

                if (!graph.ContainsKey(vertex))
                    graph[vertex] = new List<string>();
                if (!graph.ContainsKey(neighbor))
                    graph[neighbor] = new List<string>();

                graph[vertex].Add(neighbor);
            }
        }
    }
}
