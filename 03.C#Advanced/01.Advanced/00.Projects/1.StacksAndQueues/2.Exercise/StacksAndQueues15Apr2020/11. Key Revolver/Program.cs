using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceOfEachBullet = int.Parse(Console.ReadLine());
            var sizeOfGunBarrel = int.Parse(Console.ReadLine());
            var bullets = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var locks = Console
               .ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            var valueOftheIntelligence = int.Parse(Console.ReadLine());

            var bulletsStack = new Stack<int>();
            FillStack(bulletsStack, bullets);
            var locksQueue = new Queue<int>();
            FillQueue(locksQueue, locks);

            var tempBarrel = sizeOfGunBarrel;
            var count = 0;
            var flagLock = false;

            while (true)
            {
                var currBullet = bulletsStack.Pop();
                tempBarrel--;
                count++;
                var currLock = locksQueue.Peek();

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (tempBarrel == 0 && bulletsStack.Any())
                {
                    Console.WriteLine("Reloading!");
                    tempBarrel = sizeOfGunBarrel;
                }

                if (!locksQueue.Any())
                {
                    flagLock = true;
                    break;
                }

                if (!bulletsStack.Any())
                {
                    break;
                }

            }

            if (flagLock)
            {
                var moneyEarned = valueOftheIntelligence - (priceOfEachBullet * count);
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
        }

        private static void FillStack(Stack<int> stack, int[] bullets)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                stack.Push(bullets[i]);
            }
        }

        private static void FillQueue(Queue<int> queue, int[] locks)
        {
            for (int i = 0; i < locks.Length; i++)
            {
                queue.Enqueue(locks[i]);
            }
        }
    }
}
