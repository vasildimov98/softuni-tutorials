using System;
using System.Collections.Generic;

namespace Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);
            int index = 0;
            while (queue.Count >0)
            {
                int current = queue.Dequeue();
                index++;
                if (current == p)
                {
                    Console.WriteLine($"Index == {index}");
                    break;
                }

                queue.Enqueue(current + 1);
                queue.Enqueue(current * 2);
            }

        }
    }
}
