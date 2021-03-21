namespace P02.TopologicalSorting
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class DFS
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        private static HashSet<string> cycles;

        static void Main()
        {
            var countOfNodes = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            CreateGraph(countOfNodes);

            try
            {
                var ordered = TopologicalSort();
                Console.WriteLine($"Topological sorting: {string.Join(", ", ordered)}");
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

        }

        private static LinkedList<string> TopologicalSort()
        {
            var sorted = new LinkedList<string>();

            foreach (var node in graph.Keys)
            {
                if (visited.Contains(node)) continue;

                TopSortDfs(node, sorted);
            }

            return sorted;
        }

        private static void TopSortDfs(string node, LinkedList<string> sorted)
        {
            if (!cycles.Add(node))
                throw new InvalidOperationException("Invalid topological sorting");

            cycles.Remove(node);

            if (visited.Contains(node)) return;

            cycles.Add(node);
            visited.Add(node);

            foreach (var neighbor in graph[node])
                TopSortDfs(neighbor, sorted);

            cycles.Remove(node);
            sorted.AddFirst(node);
        }

        private static void CreateGraph(int countOfNodes)
        {
            for (int node = 0; node < countOfNodes; node++)
            {
                var nodeArgs = Console
                    .ReadLine()
                    .Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => n.Trim())
                    .ToList();

                var vertix = nodeArgs[0];

                if (nodeArgs.Count == 1)
                {
                    graph[vertix] = new List<string>();
                    continue;
                }

                var neighbors = nodeArgs[1]
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                graph[vertix] = new List<string>(neighbors);
            }
        }
    }
}
