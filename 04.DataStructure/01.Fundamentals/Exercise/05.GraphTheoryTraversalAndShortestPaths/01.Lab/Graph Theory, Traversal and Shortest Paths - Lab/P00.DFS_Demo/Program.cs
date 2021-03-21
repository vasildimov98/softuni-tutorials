namespace P00.DFS_Demo
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        private static List<int> dfsVisited;
        static void Main()
        {
            graph = new Dictionary<int, List<int>>
            {
                {1, new List<int> {19, 21, 14} },
                {19, new List<int> {7, 12, 31, 21} },
                {7, new List<int> {1} },
                {12, new List<int> {} },
                {31, new List<int> {21} },
                {21, new List<int> {14} },
                {14, new List<int> {6, 23} },
                {23, new List<int> {21} },
                {6, new List<int> {} },
                {33, new List<int> {56, 77} },
                {77, new List<int> {103} },
                {56, new List<int> {} },
                {103, new List<int> {} },
            };

            visited = new HashSet<int>();
            dfsVisited = new List<int>();

            foreach (var node in graph.Keys)
            {
                if (visited.Contains(node)) continue;

                DFS(node);
                Console.WriteLine(string.Join(" ", dfsVisited));
                dfsVisited.Clear();
            }
        }

        private static void DFS(int node)
        {
            if (visited.Contains(node)) return;

            visited.Add(node);

            foreach (var successors in graph[node])
                DFS(successors);

            dfsVisited.Add(node);
        }
    }
}
