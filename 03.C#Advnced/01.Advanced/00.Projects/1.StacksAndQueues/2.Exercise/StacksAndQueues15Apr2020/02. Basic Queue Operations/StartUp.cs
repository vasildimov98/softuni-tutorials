using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var data = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = data[0];
            int s = data[1];
            int x = data[2];

            var elements = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>();
            EnqueueElements(n, elements, queue);

            DequeueElements(s, queue);

            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Count > 0 ? queue.Min() : 0);
            }
        }

        private static void DequeueElements(int s, Queue<int> queue)
        {
            for (int i = 0; i < s; i++)
            {
                if (queue.Any())
                {
                    queue.Dequeue();
                }
            }
        }

        private static void EnqueueElements(int n, int[] elements, Queue<int> queue)
        {
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(elements[i]);
            }
        }
    }
}
