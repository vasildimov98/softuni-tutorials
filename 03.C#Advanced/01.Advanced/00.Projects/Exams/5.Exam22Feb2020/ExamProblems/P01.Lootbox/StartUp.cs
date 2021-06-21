using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Lootbox
{
    class StartUp
    {
        static void Main()
        {
            var firstSequence = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var secondSequence = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var queueWithLoot = new Queue<int>(firstSequence);
            var stackWithLoot = new Stack<int>(secondSequence);
            var myLoot = 0;

            while (true)
            {
                var firstItem = queueWithLoot.Peek();
                var secondItem = stackWithLoot.Pop();

                var sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    myLoot += sum;
                    queueWithLoot.Dequeue();
                }
                else
                {
                    var list = queueWithLoot.ToArray().ToList();
                    list.Add(secondItem);
                    queueWithLoot = new Queue<int>(list);
                }

                if (queueWithLoot.Count <= 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                else if (stackWithLoot.Count <= 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
            }

            if (myLoot >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {myLoot}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {myLoot}");
            }
        }
    }
}
