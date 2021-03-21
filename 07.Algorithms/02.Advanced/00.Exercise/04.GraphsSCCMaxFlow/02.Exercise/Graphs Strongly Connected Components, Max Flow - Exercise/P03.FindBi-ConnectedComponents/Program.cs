namespace P03.FindBi_ConnectedComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<int>[] graph;
        private static List<int> articulatesPoints;
        private static Stack<int> component;
        private static List<string> biComponents;
        private static bool[] visited;
        private static int[] depth;
        private static int[] lowpoint;
        private static int[] previous;

        static void Main()
        {
            ReadInput();
            FindArticulatedPoints(0, 1);
            PrintResult();
        }

        private static void PrintResult()
        {
            //Console.WriteLine($"Articulated points: {string.Join(", ", articulatesPoints)}");
            Console.WriteLine($"Number of bi-connected components: {biComponents.Count}");
            //Console.WriteLine(string.Join(Environment.NewLine, biComponents));
        }

        private static void ReadInput()
        {
            var numberOfNodes = int.Parse(Console.ReadLine());
            var numberOfLines = int.Parse(Console.ReadLine());

            ReadGraph(numberOfNodes, numberOfLines);

            articulatesPoints = new List<int>();
            component = new Stack<int>();
            biComponents = new List<string>();
            visited = new bool[numberOfNodes];
            depth = new int[numberOfNodes];
            lowpoint = new int[numberOfNodes];
            previous = new int[numberOfNodes];
            Array.Fill(previous, -1);
        }

        private static void FindArticulatedPoints(int currNode, int currNodeDepths)
        {
            visited[currNode] = true;
            depth[currNode] = currNodeDepths;
            lowpoint[currNode] = currNodeDepths;

            var childCount = 0;
            var isArticulatedPoint = false;

            foreach (var neighbor in graph[currNode])
            {
                if(!visited[neighbor])
                {
                    component.Push(currNode);
                    component.Push(neighbor);

                    previous[currNode] = neighbor;
                    childCount++;

                    FindArticulatedPoints(neighbor, currNodeDepths + 1);

                    if (lowpoint[neighbor] >= currNodeDepths)
                    {
                        isArticulatedPoint = true;

                        var currComponent = GetCurrComponent(component, currNode, neighbor);
                        biComponents.Add(string.Join(" ", currComponent));
                    }    

                    lowpoint[currNode] = Math.Min(lowpoint[currNode], lowpoint[neighbor]);
                }
                else if (neighbor != previous[currNode]
                    && lowpoint[currNode] > depth[neighbor])
                {
                    lowpoint[currNode] = depth[neighbor];
                }
            }

            if (IsArticulatedPoint(currNode, isArticulatedPoint, childCount))
            {
                articulatesPoints.Add(currNode);
            }
        }

        private static HashSet<int> GetCurrComponent(Stack<int> component, int node, int neighbor)
        {
            var outputComponent = new HashSet<int>();
            while (true)
            {
                var childNode = component.Pop();
                var currNode = component.Pop();

                outputComponent.Add(currNode);
                outputComponent.Add(childNode);

                if (currNode == node && childNode == neighbor) break;
            }

            return outputComponent;
        }

        private static bool IsArticulatedPoint(int currNode, bool isArticulatedPoint, int childCount)
        {
            return (previous[currNode] != -1 && isArticulatedPoint)
                || (previous[currNode] == -1 && childCount > 1);
        }

        private static void ReadGraph(int numberOfNodes, int numberOfLines)
        {
            graph = new List<int>[numberOfNodes];

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < numberOfLines; i++)
            {
                var edge = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edge[0];
                var secondNode = edge[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }
        }
    }
}
