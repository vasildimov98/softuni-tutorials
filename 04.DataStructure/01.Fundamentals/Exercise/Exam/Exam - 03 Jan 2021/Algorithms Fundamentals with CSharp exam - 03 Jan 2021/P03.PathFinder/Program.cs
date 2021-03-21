namespace P03.PathFinder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<int, List<int>> predecessors;
        static void Main()
        {
            ReadGraph();

            var numberOfPaths = int.Parse(Console.ReadLine());
            for (int path = 0; path < numberOfPaths; path++)
            {
                var pathToCheck = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray();

                if (CheckPath(pathToCheck))
                    Console.WriteLine("yes");
                else Console.WriteLine("no");
            }
        }

        private static bool CheckPath(int[] pathToCheck)
        {
            var currIndex = 0;
            var currNode = pathToCheck[currIndex++];
            while (currIndex < pathToCheck.Length)
            {
                var parents = predecessors[currNode];
                currNode = pathToCheck[currIndex++];
                if (!parents.Contains(currNode)) return false;
            }

            return true;
        }

        private static void ReadGraph()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            predecessors = new Dictionary<int, List<int>>();
            for (int node = 0; node < numberOfNodes; node++)
            {
                var args = Console
                    .ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (args.Length != 0)
                {
                    var children = args
                        .Select(int.Parse)
                        .ToList();

                    foreach (var child in children)
                    {
                        if (!predecessors.ContainsKey(child))
                            predecessors[child] = new List<int>();

                        predecessors[child].Add(node);
                    }
                }
            }
        }
    }
}
