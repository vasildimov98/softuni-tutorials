using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            var carpassed = 0;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    if (queue.Count >= n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            carpassed++;
                        }
                    }
                    else if (queue.Count > 0)
                    {
                        int count = queue.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            carpassed++;
                        }
                    }
                    continue;
                }

                queue.Enqueue(command);
            }

            Console.WriteLine($"{carpassed} cars passed the crossroads.");
        }
    }
}
