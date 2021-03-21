namespace P00.BFS_Demo
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;
        private static List<int> bfsVisited;

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
            bfsVisited = new List<int>();

            foreach (var node in graph.Keys)
            {
                if (visited.Contains(node)) continue;

                BFS(node);
                Console.WriteLine(string.Join(" ", bfsVisited));
                bfsVisited.Clear();
            }
        }

        private static void BFS(int startNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();
                bfsVisited.Add(currNode);

                foreach (var neighbor in graph[currNode])
                {
                    if (visited.Contains(neighbor)) continue;

                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
        }
    }
}
