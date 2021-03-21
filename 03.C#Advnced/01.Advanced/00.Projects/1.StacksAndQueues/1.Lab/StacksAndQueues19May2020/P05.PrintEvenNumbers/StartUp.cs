namespace P05.PrintEvenNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var sequence = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>();
            foreach (var number in sequence)
            {
                if (number % 2 == 0)
                {
                    queue.Enqueue(number);
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
