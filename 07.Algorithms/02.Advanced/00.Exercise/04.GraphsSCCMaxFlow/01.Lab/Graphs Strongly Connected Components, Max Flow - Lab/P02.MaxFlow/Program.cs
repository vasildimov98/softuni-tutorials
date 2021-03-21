namespace P02.MaxFlow
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int source;
        private static int target;
        private static int maxFlow;
        private static int[,] graph;
        private static int[] previous;
        static void Main()
        {
            ReadInput();
            FindMaxFlow();
            PrintResult();
        }

        private static void FindMaxFlow()
        {
            previous = new int[graph.GetLength(0)];
            Array.Fill(previous, -1);

            while (IsPossibleToReachTargetFromSource())
            {
                var currMaxFlow = FindCurrMaxFlow();
                UpdateCapacity(currMaxFlow);
                maxFlow += currMaxFlow;
            }
        }

        private static void ReadInput()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberOfNodes);

            source = int.Parse(Console.ReadLine());
            target = int.Parse(Console.ReadLine());
        }

        private static int[,] ReadGraph(int numberOfNodes)
        {
            var resultGraph = new int[numberOfNodes, numberOfNodes];

            for (int row = 0; row < resultGraph.GetLength(0); row++)
            {
                var capacities = Console
                    .ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < resultGraph.GetLength(1); col++)
                {
                    if (capacities[col] != 0)
                    {
                        resultGraph[row, col] = capacities[col];
                    }
                }
            }

            return resultGraph;
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void UpdateCapacity(int minFlow)
        {
            var currNode = target;
            while (previous[currNode] != -1)
            {
                var previousNode = previous[currNode];
                graph[previousNode, currNode] -= minFlow;
                currNode = previousNode;
            }
        }

        private static int FindCurrMaxFlow()
        {
            var currMinFlow = int.MaxValue;
            var currNode = target;

            while (previous[currNode] != -1)
            {
                var previousNode = previous[currNode];

                if (graph[previousNode, currNode] < currMinFlow)
                {
                    currMinFlow = graph[previousNode, currNode];
                }

                currNode = previousNode;
            }

            return currMinFlow;
        }

        private static bool IsPossibleToReachTargetFromSource()
        {
            var visited = new bool[graph.GetLength(0)];

            var queue = new Queue<int>();
            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();

                for (int neighbor = 0; neighbor < graph.GetLength(1); neighbor++)
                {
                    if (graph[currNode, neighbor] > 0
                        && !visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                        previous[neighbor] = currNode;
                    }
                }
            }

            return visited[target];
        }
    }
}
