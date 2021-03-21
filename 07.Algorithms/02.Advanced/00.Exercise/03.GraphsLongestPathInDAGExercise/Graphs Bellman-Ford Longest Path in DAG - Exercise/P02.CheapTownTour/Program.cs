namespace P02.CheapTownTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
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
    }

    class Program
    {
        private static int nodes;
        private static List<Edge> graph;
        private static int[] root;
        static void Main()
        {
            ReadInput();
            var totalCost = FindMinimumTotalCost();
            PrintTotalCost(totalCost);
        }

        private static void PrintTotalCost(int totalCost)
        {
            Console.WriteLine($"Total cost: {totalCost}");
        }

        private static int FindMinimumTotalCost()
        {
            var cost = 0;

            root = SetInitialRoots();

            var sortedEdges = graph
                .OrderBy(e => e.Weight);

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = GetRoot(edge.FirstNode);
                var secondNodeRoot = GetRoot(edge.SecondNode);

                if (firstNodeRoot != secondNodeRoot)
                {
                    root[secondNodeRoot] = firstNodeRoot;
                    cost += edge.Weight;
                }
            }

            return cost;
        }

        private static int[] SetInitialRoots()
        {
            var root = new int[nodes];

            for (int node = 0; node < root.Length; node++)
            {
                root[node] = node;
            }

            return root;
        }

        private static int GetRoot(int node)
        {
            var currRoot = node;

            while (root[currRoot] != currRoot)
            {
                currRoot = root[currRoot];
            }

            while (currRoot != node)
            {
                var previousRoot = root[node];
                root[node] = currRoot;
                node = previousRoot;
            }

            return currRoot;
        }

        private static void ReadInput()
        {
            nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            graph = ReadGraph(nodes, edges);
        }

        private static List<Edge> ReadGraph(int nodes, int edges)
        {
            var result = new List<Edge>();

            for (int i = 0; i < edges; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeArgs[0];
                var secondNode = edgeArgs[1];
                var weight = edgeArgs[2];

                var edge = new Edge(firstNode, secondNode, weight);

                result.Add(edge);
            }

            return result;
        }
    }
}
