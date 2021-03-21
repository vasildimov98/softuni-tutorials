namespace P02.MaximumTasksAssignment
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static int people;
        private static int task;
        private static int[,] graph;
        private static int[] previous;
        private static List<string> assignment;
        static void Main()
        {
            // S A B C 1 2 3 E
            // 0 1 2 3 4 5 6 7

            ReadInput();
            FindMaximalTaskAssignment();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(Environment.NewLine, assignment));
        }

        private static void ReadInput()
        {
            people = int.Parse(Console.ReadLine());
            task = int.Parse(Console.ReadLine());

            ReadMatrix();
        }

        private static void FindMaximalTaskAssignment()
        {
            var startNode = 0;
            var endNode = people + task + 1;

            previous = new int[endNode + 1];
            Array.Fill(previous, -1);
            while (BFS(startNode, endNode))
            {
                UpdateRows(endNode);
            }

            assignment = new List<string>();
            for (int person =  1; person <= people; person++)
            {
                for (int task = people + 1; task < endNode; task++)
                {
                    if (graph[task, person] > 0)
                    {
                        assignment.Add($"{(char)(64 + person)}-{task - people}");
                        break;
                    }
                }
            }
        }

        private static void UpdateRows(int currNode)
        {
            while (previous[currNode] != -1)
            {
                var previousNode = previous[currNode];

                graph[previousNode, currNode] = 0;
                graph[currNode, previousNode] = 1;

                currNode = previousNode;
            }
        }

        private static bool BFS(int node, int endNode)
        {
            var visited = new bool[people + task + 2];

            var queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node] = true;

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();

                if (currNode == endNode) return true;

                for (int neighbor = 0; neighbor <= endNode; neighbor++)
                {
                    if (graph[currNode, neighbor] == 1
                        && !visited[neighbor])
                    {
                        previous[neighbor] = currNode;
                        if (neighbor == endNode) return true;

                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return visited[endNode];
        }

        private static void ReadMatrix()
        {
            var totalNodes = people + task + 2;
            graph = new int[totalNodes, totalNodes];

            var startNode = 0;
            var endNode = totalNodes - 1;

            for (int person = 1; person <= people; person++)
            {
                graph[startNode, person] = 1;
            }

            for (int task = people + 1; task < totalNodes - 1; task++)
            {
                graph[task, endNode] = 1;
            }

            for (int person = 1; person <= people; person++)
            {
                var line = Console.ReadLine();

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'Y')
                    {
                        var task = people + 1 + i;

                        graph[person, task] = 1;
                    }
                }
            }
        }
    }
}
