using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var pumps = new Queue<int[]>();
            FillTheQueue(pumps, n);

            var count = 0;
            while (true)
            {
                var currentPetrol = 0;
                var found = true;

                foreach (var pump in pumps)
                {
                    currentPetrol += pump[0];

                    if (currentPetrol < pump[1])
                    {
                        found = false;
                        break;
                    }

                    currentPetrol -= pump[1];
                }

                if (found)
                {
                    break;
                }

                count++;
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(count);
        }

        private static void FillTheQueue(Queue<int[]> queue, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(input);
            }
        }
    }
}
