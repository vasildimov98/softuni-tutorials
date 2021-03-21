namespace P01.ElectricalSubstationNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<int>[] originalGraph;
        private static List<int>[] reverseGraph;
        private static Stack<int> sortedNodes;
        private static List<Stack<int>> components;

        private static bool[] visited;
        static void Main()
        {
            ReadInput();
            FindAllComponents();
            PrintResult();
        }

        private static void ReadInput()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var numberOfLines = int.Parse(Console.ReadLine());

            InitializeGraphs(numberOfNodes, numberOfLines);
        }

        private static void PrintResult()
        {
            foreach (var component in components)
            {
                Console.WriteLine(string.Join(", ", component));
            }
        }

        private static void FindAllComponents()
        {
            TopologicalSort();
            components = new List<Stack<int>>();

            visited = new bool[reverseGraph.Length];
            while (sortedNodes.Count > 0)
            {
                var currNode = sortedNodes.Pop();

                if (visited[currNode]) continue;

                var component = new Stack<int>();

                DFS(currNode, visited, reverseGraph, component);

                components.Add(component);
            }
        }

        private static void TopologicalSort()
        {
            sortedNodes = new Stack<int>();

            visited = new bool[originalGraph.Length];

            for (int node = 0; node < originalGraph.Length; node++)
            {
                if (visited[node]) continue;

                DFS(node, visited, originalGraph, sortedNodes);
            }
        }

        private static void DFS(int node, bool[] visited, List<int>[] graph, Stack<int> output)
        {
            if (visited[node]) return;

            visited[node] = true;

            foreach (var neighbor in graph[node])
            {
                DFS(neighbor, visited, graph, output);
            }

            output.Push(node);
        }

        private static void InitializeGraphs(int numberOfNodes, int numberOfLines)
        {
            originalGraph = new List<int>[numberOfNodes];
            reverseGraph = new List<int>[numberOfNodes];

            for (int node = 0; node < numberOfNodes; node++)
            {
                originalGraph[node] = new List<int>();
                reverseGraph[node] = new List<int>();
            }

            for (int i = 0; i < numberOfLines; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var node = edgeArgs[0];
                originalGraph[node].AddRange(edgeArgs.Skip(1));

                for (int j = 1; j < edgeArgs.Length; j++)
                {
                    reverseGraph[edgeArgs[j]].Add(node);
                }
            }
        }
    }
}
