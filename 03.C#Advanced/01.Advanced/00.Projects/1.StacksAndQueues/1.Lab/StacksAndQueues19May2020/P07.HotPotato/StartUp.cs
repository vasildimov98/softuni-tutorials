namespace P07.HotPotato
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var names = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var n = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(names);

            var count = 1;
            while (queue.Count > 1)
            {
                var person = queue.Dequeue();

                if (!(count == n))
                {
                    queue.Enqueue(person);
                }
                else
                {
                    Console.WriteLine($"Removed {person}");
                    count = 0;
                }

                count++;
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
