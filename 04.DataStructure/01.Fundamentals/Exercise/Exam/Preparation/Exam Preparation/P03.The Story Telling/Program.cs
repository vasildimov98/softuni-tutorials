namespace P03.The_Story_Telling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        static void Main()
        {
            graph = ReadGraph();
            visited = new HashSet<string>();
            var traversal = new Stack<string>();
            foreach (var node in graph.Keys)
            {
                DFSRead(node, traversal);
            }
            Console.WriteLine(string.Join(" ", traversal));
        }

        private static void DFSRead(string node, Stack<string> stack)
        {
            if (visited.Contains(node)) return;

            visited.Add(node);

            foreach (var neighbor in graph[node])
                DFSRead(neighbor, stack);

            stack.Push(node);
        }

        private static Dictionary<string, List<string>> ReadGraph()
        {
            var graph = new Dictionary<string, List<string>>();
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                var args = line
                    .Split(" ->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.Trim())
                    .ToArray();

                var preStory = args[0];

                if (!graph.ContainsKey(preStory))
                    graph[preStory] = new List<string>();

                if (args.Length == 1) continue;

                var postStories = args[1].Split().ToArray();
                graph[preStory].AddRange(postStories);
            }

            return graph;
        }
    }
}
