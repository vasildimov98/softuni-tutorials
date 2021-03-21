namespace P03.Prim_sAlgorithm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    class Edge
    {
        public Edge(int firtNode, int secondNode, int weight)
        {
            this.FirtNode = firtNode;
            this.SecondNode = secondNode;
            this.Weight = weight;
        }

        public int FirtNode { get; set; }
        public int SecondNode { get; set; }
        public int Weight { get; set; }
    }
    class Program
    {
        private static Dictionary<int, List<Edge>> graph;
        private static HashSet<int> spanningTrees;
        private static List<string> forest;

        static void Main()
        {
            ReadInput();
            FindMinimumSpanningTree();
            PrintResult();
        }

        private static void PrintResult()
        {
            forest.ForEach(Console.WriteLine);
        }

        private static void FindMinimumSpanningTree()
        {
            foreach (var node in graph.Keys)
            {
                if (spanningTrees.Contains(node)) continue;

                Prim(node);
            }
        }

        private static void Prim(int node)
        {
            spanningTrees.Add(node);
            var queue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));
            queue.AddMany(graph[node]);

            while (queue.Count > 0)
            {
                var minEdge = queue.RemoveFirst();

                var foundNonTreeNode = FindNonTreeNode(minEdge.FirtNode, minEdge.SecondNode);

                if (foundNonTreeNode == -1) continue;

                forest.Add($"{minEdge.FirtNode} - {minEdge.SecondNode}");
                spanningTrees.Add(foundNonTreeNode);
                queue.AddMany(graph[foundNonTreeNode]);
            }
        }

        private static int FindNonTreeNode(int firtNode, int secondNode)
        {
            var node = -1;

            if (spanningTrees.Contains(firtNode)
                && !spanningTrees.Contains(secondNode))
            {
                node = secondNode;
            }

            if (spanningTrees.Contains(secondNode)
               && !spanningTrees.Contains(firtNode))
            {
                node = firtNode;
            }

            return node;
        }

        private static void ReadInput()
        {
            graph = ReadGraph();
            spanningTrees = new HashSet<int>();
            forest = new List<string>();
        }

        private static Dictionary<int, List<Edge>> ReadGraph()
        {
            var edgesCount = int.Parse(Console.ReadLine());

            var result = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split(new char[] { ' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeArgs[0];
                var secondNode = edgeArgs[1];
                var weightNode = edgeArgs[2];

                if (!result.ContainsKey(firstNode))
                    result[firstNode] = new List<Edge>();

                if (!result.ContainsKey(secondNode))
                    result[secondNode] = new List<Edge>();

                var edge = new Edge(firstNode, secondNode, weightNode);

                result[firstNode].Add(edge);
                result[secondNode].Add(edge);
            }

            return result;
        }
    }
}
