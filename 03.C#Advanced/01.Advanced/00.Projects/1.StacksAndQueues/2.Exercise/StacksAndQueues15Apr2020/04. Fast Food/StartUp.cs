using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var foodQuantity = int.Parse(Console.ReadLine());

            var ordersQuanity = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>();
            EnqueueElements(ordersQuanity, queue);

            Console.WriteLine(queue.Max());

            if (foodQuantity != 0)
            {
                for (int i = 0; i < ordersQuanity.Length; i++)
                {
                    if (queue.Peek() <= foodQuantity)
                    {
                        foodQuantity -= queue.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (queue.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }

        private static void EnqueueElements(int[] ordersQuanity, Queue<int> queue)
        {
            for (int i = 0; i < ordersQuanity.Length; i++)
            {
                queue.Enqueue(ordersQuanity[i]);
            }
        }
    }
}
