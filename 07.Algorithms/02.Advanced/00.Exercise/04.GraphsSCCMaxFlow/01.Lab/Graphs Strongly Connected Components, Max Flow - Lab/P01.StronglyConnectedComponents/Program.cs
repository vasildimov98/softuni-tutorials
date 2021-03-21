namespace P01.StronglyConnectedComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<int>[] graph;
        private static List<int>[] reverseGraph;
        private static List<Stack<int>> stronglyConnectedComponents;
        static void Main()
        {
            ReadInput();
            stronglyConnectedComponents = FindAllStronglyConnectedComponents();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine("Strongly Connected Components:");
            foreach (var comp in stronglyConnectedComponents)
            {
                Console.WriteLine($"{{{string.Join(", ", comp)}}}");
            }
        }

        private static List<Stack<int>> FindAllStronglyConnectedComponents()
        {
            var scc = new List<Stack<int>>();

            var sortedNode = TopologicalSorted();
            reverseGraph = ReverseGraph();

            var visited = new bool[sortedNode.Count];
            while (sortedNode.Count > 0)
            {
                var currNode = sortedNode.Pop();

                if (visited[currNode]) continue;

                var component = new Stack<int>();
                ReverseDFS(currNode, visited, component);

                scc.Add(component);
            }

            return scc;
        }

        private static void ReverseDFS(int currNode, bool[] visited, Stack<int> component)
        {
            if (visited[currNode]) return;

            visited[currNode] = true;

            foreach (var neighbor in reverseGraph[currNode])
            {
                ReverseDFS(neighbor, visited, component);
            }

            component.Push(currNode);
        }

        private static List<int>[] ReverseGraph()
        {
            var reverseGraph = new List<int>[graph.Length];

            for (int node = 0; node < reverseGraph.Length; node++)
            {
                reverseGraph[node] = new List<int>();
            }

            for (int node = 0; node < graph.Length; node++)
            {
                foreach (var neighbor in graph[node])
                {
                    reverseGraph[neighbor].Add(node);
                }
            }

            return reverseGraph;
        }

        private static Stack<int> TopologicalSorted()
        {
            var sorted = new Stack<int>();

            var visited = new bool[graph.Length];

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node]) continue;

                DFS(node, visited, sorted);
            }

            return sorted;
        }

        private static void DFS(int node, bool[] visited, Stack<int> sorted)
        {
            if (visited[node]) return;

            visited[node] = true;

            foreach (var neighbor in graph[node])
            {
                DFS(neighbor, visited, sorted);
            }

            sorted.Push(node);
        }

        private static void ReadInput()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var numberOfEdges = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberOfNodes, numberOfEdges);
        }

        private static List<int>[] ReadGraph(int numberOfNodes, int numberOfEdges)
        {
            var resultGraph = new List<int>[numberOfNodes];

            for (int node = 0; node < resultGraph.Length; node++)
            {
                resultGraph[node] = new List<int>();
            }

            for (int i = 0; i < numberOfEdges; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var fromNode = edgeArgs[0];

                for (int j = 1; j < edgeArgs.Length; j++)
                {
                    resultGraph[fromNode].Add(edgeArgs[j]);
                }
            }

            return resultGraph;
        }
    }
}
