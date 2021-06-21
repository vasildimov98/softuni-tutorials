using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.ClubParty
{
    class StartUp
    {
        static void Main()
        {
            var halls = new Dictionary<char, List<int>>();
            var capacity = int.Parse(Console.ReadLine());

            var input = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var stack = new Stack<string>(input);
            var queue = new Queue<char>();

            while (stack.Any())
            {
                var current = stack.Pop();

                if (char.IsLetter(current[0]))
                {
                    queue.Enqueue(current[0]);
                    halls.Add(current[0], new List<int>());
                }

                if (!queue.Any())
                {
                    continue;
                }

                if (char.IsDigit(current[0]))
                {
                    var reservation = int.Parse(current);

                    var hall = queue.Peek();

                    var peopleInTheHall = halls[hall].Sum();

                    if (peopleInTheHall + reservation > capacity)
                    {
                        PrintHall(halls, queue, hall);

                        hall = CheckForNextHall(halls, queue, reservation, hall);
                    }
                    else
                    {
                        halls[hall].Add(reservation);
                    }
                }
            }
        }

        private static char CheckForNextHall(Dictionary<char, List<int>> halls, Queue<char> queue, int reservation, char hall)
        {
            if (queue.Any())
            {
                hall = queue.Peek();

                halls[hall].Add(reservation);
            }

            return hall;
        }

        private static void PrintHall(Dictionary<char, List<int>> halls, Queue<char> queue, char hall)
        {
            Console.WriteLine($"{hall} -> {string.Join(", ", halls[hall])}");
            queue.Dequeue();
        }
    }
}

