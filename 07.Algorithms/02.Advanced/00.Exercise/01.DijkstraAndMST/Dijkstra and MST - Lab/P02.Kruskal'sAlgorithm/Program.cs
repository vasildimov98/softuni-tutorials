namespace P02.Kruskal_sAlgorithm
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    class Edge : IComparable<Edge>
    {
        public Edge(int firstNode, int secondNode, int weight)
        {
            this.FirstNode = firstNode;
            this.SecondNode = secondNode;
            this.Weight = weight;
        }

        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public int Weight { get; set; }

        public int CompareTo([AllowNull] Edge other)
            => this.Weight - other.Weight;
    }

    class Program
    {
        private static List<string> forest;
        private static List<Edge> edges;
        private static int[] parent;
        private static int maxNode;
        static void Main()
        {
            ReadInput();
            FindMinimumSpanningTree();
            PrintMinumunSpanningTree();
        }

        private static void PrintMinumunSpanningTree()
        {
            forest.ForEach(Console.WriteLine);
        }

        private static void FindMinimumSpanningTree()
        {
            foreach (var currMinEdge in edges)
            {
                var firstNode = currMinEdge.FirstNode;
                var secondNode = currMinEdge.SecondNode;

                var firstNodeRoot = FindNodeRoot(firstNode);
                var secondNodeRoot = FindNodeRoot(secondNode);

                if (firstNodeRoot != secondNodeRoot)
                {
                    forest.Add($"{firstNode} - {secondNode}");
                    parent[secondNodeRoot] = firstNodeRoot;
                }
            }
        }

        private static int FindNodeRoot(int currNode)
        {
            var currRoot = currNode;
            while (parent[currRoot] != currRoot)
            {
                currRoot = parent[currRoot];
            }

            while (currNode != currRoot)
            {
                var previous = parent[currNode];
                parent[currNode] = currRoot;
                currNode = previous;
            }

            return currRoot;
        }

        private static void ReadInput()
        {
            forest = new List<string>();
            edges = ReadEdges();
            parent = ReadParent();
        }

        private static int[] ReadParent()
        {
            var arr = new int[maxNode + 1];

            for (int node = 0; node < arr.Length; node++)
            {
                arr[node] = node;
            }

            return arr;
        }

        private static List<Edge> ReadEdges()
        {
            maxNode = int.MinValue;
            var sortedSet = new List<Edge>();

            var edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeArgs[0];
                var secondNode = edgeArgs[1];
                var weight = edgeArgs[2];

                if (firstNode > maxNode)
                    maxNode = firstNode;

                if (secondNode > maxNode)
                    maxNode = secondNode;

                var edge = new Edge(firstNode, secondNode, weight);

                sortedSet.Add(edge);
            }

            sortedSet.Sort();
            return sortedSet;
        }
    }
}
