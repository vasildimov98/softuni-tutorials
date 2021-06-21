using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var childrens = Console
                .ReadLine()
                .Split();
            var toss = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(childrens);
            int count = 0;
            while (queue.Count > 1)
            {
                count++;
                var children = queue.Dequeue();

                if (count == toss)
                {
                    Console.WriteLine($"Removed {children}");
                    count = 0;
                    continue;
                }

                queue.Enqueue(children);
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
