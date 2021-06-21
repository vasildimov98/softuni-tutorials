using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsCapacity = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var filledBottles = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queueCups = new Queue<int>();
            FillQueue(queueCups, cupsCapacity);

            var stackBottles = new Stack<int>();
            FillStack(stackBottles, filledBottles);

            var wastedWater = 0;
            var IsManaged = true;

            while (queueCups.Any())
            {
                var currCup = queueCups.Peek();
                while (currCup > 0)
                {
                    if (!stackBottles.Any())
                    {
                        break;
                    }
                    currCup -= stackBottles.Pop();
                }
                queueCups.Dequeue();

                if (currCup < 0)
                {
                    wastedWater += Math.Abs(currCup);
                }

                if (!stackBottles.Any())
                {
                    IsManaged = false;
                    break;
                }
            }

            if (IsManaged)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stackBottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", queueCups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        private static void FillQueue(Queue<int> queue, int[] cups)
        {
            for (int i = 0; i < cups.Length; i++)
            {
                queue.Enqueue(cups[i]);
            }
        }

        private static void FillStack(Stack<int> stack, int[] bottles)
        {
            for (int i = 0; i < bottles.Length; i++)
            {
                stack.Push(bottles[i]);
            }
        }
    }
}
