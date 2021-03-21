namespace P05.CableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

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
        private static int budget;
        private static List<Edge>[] graph;
        private static readonly HashSet<int> spanningTree = new HashSet<int>();

        static void Main()
        {
            ReadInput();
            var usedBudget = CalculateBudget();
            PrintResult(usedBudget);
        }

        private static void PrintResult(int usedBudget)
        {
            Console.WriteLine($"Budget used: {usedBudget}");
        }

        private static int CalculateBudget()
        {
            var usedBudget = 0;

            var priorityQueue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight.CompareTo(s.Weight)));

            AddAllNeighborsOfConnectedNodes(priorityQueue);

            while (priorityQueue.Any())
            {
                var currEdge = priorityQueue.RemoveFirst();

                if (currEdge.Weight > budget) break;

                var nonTreeNode = GetNonTreeNode(currEdge);

                if (nonTreeNode == -1) continue;

                usedBudget += currEdge.Weight;
                budget -= currEdge.Weight;

                spanningTree.Add(nonTreeNode);
                priorityQueue.AddMany(graph[nonTreeNode]);
            }

            return usedBudget;
        }

        private static int GetNonTreeNode(Edge currEdge)
        {
            var nonTreeNode = -1;

            if (spanningTree.Contains(currEdge.FirstNode)
                && !spanningTree.Contains(currEdge.SecondNode))
            {
                nonTreeNode = currEdge.SecondNode;
            }

            if (spanningTree.Contains(currEdge.SecondNode)
               && !spanningTree.Contains(currEdge.FirstNode))
            {
                nonTreeNode = currEdge.FirstNode;
            }

            return nonTreeNode;
        }

        private static void AddAllNeighborsOfConnectedNodes(OrderedBag<Edge> priorityQueue)
        {
            foreach (var node in spanningTree)
            {
                priorityQueue.AddMany(graph[node]);
            }
        }

        private static void ReadInput()
        {
            budget = int.Parse(Console.ReadLine());

            var numberOfNodes = int.Parse(Console.ReadLine());
            var numberOfEdges = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberOfNodes, numberOfEdges);
        }

        private static List<Edge>[] ReadGraph(int numberOfNodes, int numberOfEdges)
        {
            var result = Enumerable.Repeat(new List<Edge>(), numberOfNodes).ToArray();

            for (int i = 0; i < numberOfEdges; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split()
                    .ToArray();

                var firstNode = int.Parse(edgeArgs[0]);
                var secondNode = int.Parse(edgeArgs[1]);
                var weight = int.Parse(edgeArgs[2]);

                var edge = new Edge(firstNode, secondNode, weight);

                result[firstNode].Add(edge);
                result[secondNode].Add(edge);

                if (edgeArgs.Length == 4)
                {
                    spanningTree.Add(firstNode);
                    spanningTree.Add(secondNode);
                }
            }

            return result;
        }
    }
}
