namespace P01.BlackFriday
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    internal class Edge
    {
        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public int Time { get; set; }
    }

    public class Program
    {
        private static List<Edge>[] graph;
        private static List<int> spanningTree;
        private static int totalTime;
        static void Main()
        {
            ReadInput();
            FindMST();
        }

        private static void FindMST()
        {
            spanningTree = new List<int>();

            for (int node = 0; node < graph.Length; node++)
            {
                if (!spanningTree.Contains(node))
                {
                    Prim(node);
                }
            }

            Console.WriteLine(totalTime);
        }

        private static void Prim(int node)
        {
            spanningTree.Add(node);
            var priorityQueue =
             new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Time - s.Time));

            priorityQueue.AddMany(graph[node]);

            while (priorityQueue.Any())
            {
                var minNode = priorityQueue.RemoveFirst();

                var noneTreeNode = FindNoneTreeNode(minNode);

                if (noneTreeNode != -1)
                {
                    spanningTree.Add(noneTreeNode);

                    priorityQueue.AddMany(graph[noneTreeNode]);
                }
            }
        }

        private static int FindNoneTreeNode(Edge minNode)
        {
            var noneTreeNode = -1;

            if (spanningTree.Contains(minNode.FirstNode)
                && !spanningTree.Contains(minNode.SecondNode))
            {
                noneTreeNode = minNode.SecondNode;
                totalTime += minNode.Time;
            }

            if (spanningTree.Contains(minNode.SecondNode)
                && !spanningTree.Contains(minNode.FirstNode))
            {
                noneTreeNode = minNode.FirstNode;
                totalTime += minNode.Time;
            }


            return noneTreeNode;
        }

        private static void ReadInput()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = ReadEdge(nodes, edges);
        }

        private static List<Edge>[] ReadEdge(int nodes, int edges)
        {
            var output = new List<Edge>[nodes];

            for (int node = 0; node < nodes; node++)
            {
                output[node] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = args[0];
                var secondNode = args[1];
                var time = args[2];

                var edge = new Edge
                {
                    FirstNode = firstNode,
                    SecondNode = secondNode,
                    Time = time
                };

                output[firstNode].Add(edge);
                output[secondNode].Add(edge);
            }

            return output;
        }
    }
}
