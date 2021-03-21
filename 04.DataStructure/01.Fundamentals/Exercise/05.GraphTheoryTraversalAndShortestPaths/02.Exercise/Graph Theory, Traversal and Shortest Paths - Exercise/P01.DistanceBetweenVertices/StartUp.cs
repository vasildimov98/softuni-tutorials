namespace P01.DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        private static Dictionary<int, List<int>> graph;
        static void Main()
        {
            graph = new Dictionary<int, List<int>>();
            var numberOfVertices = int.Parse(Console.ReadLine());
            var numberOfPairs = int.Parse(Console.ReadLine());

            ReadGrapgh(numberOfVertices);

            for (int i = 0; i < numberOfPairs; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split('-')
                    .Select(int.Parse)
                    .ToArray();

                var source = args[0];
                var distance = args[1];

                var foundShortestStep = FindShortestStep(source, distance);

                Console.WriteLine($"{{{source}, {distance}}} -> {foundShortestStep}");
            }
        }

        private static int FindShortestStep(int startNode, int endNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            var steps = new Dictionary<int, int> { { startNode, 0} };
            while (queue.Any())
            {
                var currNode = queue.Dequeue();

                if (currNode == endNode)
                    return steps[currNode];

                foreach (var neighbor in graph[currNode])
                {
                    if (steps.ContainsKey(neighbor)) continue;
                    queue.Enqueue(neighbor);
                    steps[neighbor] = steps[currNode] + 1;
                }
            }

            return -1;
        }

        private static void ReadGrapgh(int numberOfVertices)
        {
            for (int i = 0; i < numberOfVertices; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var vertex = int.Parse(args[0]);

                graph[vertex] = new List<int>();

                if (args.Length > 1)
                {
                    var neighbors = args[1]
                        .Split()
                        .Select(int.Parse)
                        .ToList();

                    graph[vertex].AddRange(neighbors);
                }
            }
        }
    }
}
