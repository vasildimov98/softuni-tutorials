//namespace P02.TopologicalSorting
//{
//    using System;
//    using System.Linq;
//    using System.Collections.Generic;

//    class Iterative
//    {
//        private static Dictionary<string, List<string>> graph;
//        private static Dictionary<string, int> dependencies;

//        static void Main()
//        {
//            var countOfNodes = int.Parse(Console.ReadLine());
//            graph = new Dictionary<string, List<string>>();
//            dependencies = new Dictionary<string, int>();

//            CreateGraph(countOfNodes);
//            FindDependacies();

//            try
//            {
//                var ordered = TopologicalSort();
//                Console.WriteLine($"Topological sorting: {string.Join(", ", ordered)}");
//            }
//            catch (Exception exp)
//            {
//                Console.WriteLine(exp.Message);
//            }

//        }

//        private static List<string> TopologicalSort()
//        {
//            var sorted = new List<string>();
//            while (dependencies.Count > 0)
//            {
//                var undependentNode = dependencies
//                    .FirstOrDefault(d => d.Value == 0);

//                if (undependentNode.Key == null)
//                    throw new InvalidOperationException("Invalid topological sorting");

//                foreach (var node in graph[undependentNode.Key])
//                    dependencies[node]--;

//                sorted.Add(undependentNode.Key);
//                dependencies.Remove(undependentNode.Key);
//            }

//            return sorted;
//        }

//        private static void FindDependacies()
//        {
//            foreach (var node in graph)
//            {
//                var currVertex = node.Key;
//                var neighbors = node.Value;

//                if (!dependencies.ContainsKey(currVertex))
//                    dependencies[currVertex] = 0;

//                foreach (var neighbor in neighbors)
//                {
//                    if (!dependencies.ContainsKey(neighbor))
//                        dependencies[neighbor] = 0;

//                    dependencies[neighbor]++;
//                }
//            }
//        }

//        private static void CreateGraph(int countOfNodes)
//        {
//            for (int node = 0; node < countOfNodes; node++)
//            {
//                var nodeArgs = Console
//                    .ReadLine()
//                    .Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
//                    .Select(n => n.Trim())
//                    .ToList();

//                var vertix = nodeArgs[0];

//                if (nodeArgs.Count == 1)
//                {
//                    graph[vertix] = new List<string>();
//                    continue;
//                }

//                var neighbors = nodeArgs[1]
//                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
//                    .ToArray();

//                graph[vertix] = new List<string>(neighbors);
//            }
//        }
//    }
//}
