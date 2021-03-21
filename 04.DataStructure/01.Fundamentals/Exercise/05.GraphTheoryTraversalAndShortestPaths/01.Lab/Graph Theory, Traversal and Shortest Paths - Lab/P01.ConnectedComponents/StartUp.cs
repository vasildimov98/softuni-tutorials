namespace P01.ConnectedComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<int>[] graph;
        private static bool[] visited;

        public static void Main()
        {
            FindAllConnectedComponents();
        }

        private static void FindAllConnectedComponents()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            graph = new List<int>[numberOfNodes];
            CreateTheGraph(numberOfNodes);

            visited = new bool[graph.Length];
            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node]) continue;

                var connectedComponent = new List<int>();
                DFS(node, connectedComponent);
                Console.WriteLine($"Connected component: {string.Join(" ", connectedComponent)}");
            }
        }

        private static void DFS(int node, List<int> component)
        {
            if (visited[node]) return;

            visited[node] = true;

            foreach (var neighbor in graph[node])
                DFS(neighbor, component);

            component.Add(node);
        }

        private static void CreateTheGraph(int numberOfNodes)
        {
            for (int node = 0; node < numberOfNodes; node++)
            {
                var input = Console
                    .ReadLine();

                if (input == "")
                {
                    graph[node] = new List<int>();
                    continue;
                }

                var neighbors = input
                    .Split(" ")
                    .Select(int.Parse)
                    .ToList();

                graph[node] = neighbors;
            }
        }
    }
}
