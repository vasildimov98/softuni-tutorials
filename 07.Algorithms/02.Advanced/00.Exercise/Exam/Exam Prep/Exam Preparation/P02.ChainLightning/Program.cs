namespace P02.ChainLightning
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    internal class Edge
    {
        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public int Distance { get; set; }
    }

    public class Program
    {
        private static List<Edge>[] graph;
        private static int numberOfLightnings;
        public static void Main()
        {
            ReadInput();
            var result = CalculateTheMostDamageNeighbor();
            PrintResult(result);
        }

        private static void PrintResult(int result)
        {
            Console.WriteLine(result);
        }

        private static int CalculateTheMostDamageNeighbor()
        {
            var damageNodes = new Dictionary<int, int>();

            for (int i = 0; i < numberOfLightnings; i++)
            {
                var casultyArgs = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var startNode = casultyArgs[0];
                var damage = casultyArgs[1];

                var minSpanningTree = Prim(startNode);

                foreach (var nodeDamage in minSpanningTree)
                {
                    if (!damageNodes.ContainsKey(nodeDamage.Key))
                        damageNodes[nodeDamage.Key] = 0;

                    var currDamage = damage;

                    for (int index = 0; index < nodeDamage.Value; index++)
                    {
                        currDamage /= 2;
                    }

                    damageNodes[nodeDamage.Key] += currDamage;
                }
            }

            return damageNodes.Max(n => n.Value);
        }

        private static Dictionary<int, int> Prim(int startNode)
        {
            var queue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Distance - s.Distance));
            var spanningTree = new Dictionary<int, int> { [startNode] = 0 };

            queue.AddMany(graph[startNode]);

            while (queue.Any())
            {
                var currNode = queue.RemoveFirst();

                var notInTreeNode = GetNotInTreeNode(currNode, spanningTree);

                if (notInTreeNode == -1) continue;

                var inTreeNode = GetInTreeNode(currNode, spanningTree);

                spanningTree.Add(notInTreeNode, spanningTree[inTreeNode] + 1);

                queue.AddMany(graph[notInTreeNode]);
            }

            return spanningTree;
        }

        private static int GetInTreeNode(Edge currNode, Dictionary<int, int> spanningTree)
        {
            if (spanningTree.ContainsKey(currNode.FirstNode)
               && !spanningTree.ContainsKey(currNode.SecondNode))
                return currNode.FirstNode;
            else return currNode.SecondNode;
        }

        private static int GetNotInTreeNode(Edge currNode, Dictionary<int, int> spanningTree)
        {
            var notInTreeOutput = -1;

            if (spanningTree.ContainsKey(currNode.FirstNode)
                && !spanningTree.ContainsKey(currNode.SecondNode))
            {
                notInTreeOutput = currNode.SecondNode;
            }

            if (spanningTree.ContainsKey(currNode.SecondNode)
                && !spanningTree.ContainsKey(currNode.FirstNode))
            {
                notInTreeOutput = currNode.FirstNode;
            }

            return notInTreeOutput;
        }

        private static void ReadInput()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var numberOfEdges = int.Parse(Console.ReadLine());
            numberOfLightnings = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberOfNodes, numberOfEdges);
        }

        private static List<Edge>[] ReadGraph(int numberOfNodes, int numberOfEdges)
        {
            var output = new List<Edge>[numberOfNodes];

            for (int node = 0; node < output.Length; node++)
            {
                output[node] = new List<Edge>();
            }

            for (int i = 0; i < numberOfEdges; i++)
            {
                var edgeArgs = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var edge = new Edge
                {
                    FirstNode = edgeArgs[0],
                    SecondNode = edgeArgs[1],
                    Distance = edgeArgs[2]
                };

                output[edge.FirstNode].Add(edge);
                output[edge.SecondNode].Add(edge);
            }

            return output;
        }
    }
}
