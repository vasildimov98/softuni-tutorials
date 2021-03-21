using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            var queue = new Queue<string>();

            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    Console.WriteLine(string.Join(Environment.NewLine, queue));
                    queue.Clear();
                    continue;
                }
                queue.Enqueue(command);
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
