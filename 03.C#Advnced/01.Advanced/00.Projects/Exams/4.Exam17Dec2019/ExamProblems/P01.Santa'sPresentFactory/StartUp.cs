using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Santa_sPresentFactory
{

    class StartUp
    {
        private const int DOLL_MAGIC_NEEDED_VALUE = 150;
        private const int WOODEN_TRAIN_MAGIC_NEEDED_VALUE = 250;
        private const int TEDDY_BEAR_MAGIC_NEEDED_VALUE = 300;
        private const int BICYCLE_MAGIC_NEEDED_VALUE = 400;

        private const string doll = "Doll";
        private const string woodenTrain = "Wooden train";
        private const string teddyBear = "Teddy bear";
        private const string bicycle = "Bicycle";

        private static Dictionary<string, int> dict = new Dictionary<string, int>();

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

            var stackWithMatirials = new Stack<int>(firstSequence);
            var ququesWithMagic = new Queue<int>(secondSequence);

            while (stackWithMatirials.Any() && ququesWithMagic.Any())
            {
                var matirial = stackWithMatirials.Peek();
                var magicLevel = ququesWithMagic.Peek();

                if (matirial == 0 || magicLevel == 0)
                {
                    if (matirial == 0)
                    {
                        stackWithMatirials.Pop();
                    }

                    if (magicLevel == 0)
                    {
                        ququesWithMagic.Dequeue();
                    }
                    continue;
                }

                var product = matirial * magicLevel;

                if (product < 0)
                {
                    var sum = matirial + magicLevel;

                    stackWithMatirials.Pop();
                    stackWithMatirials.Push(sum);
                    ququesWithMagic.Dequeue();

                    continue;
                }

                CraftPresent(stackWithMatirials,
                    ququesWithMagic,
                    matirial,
                    product);
            }

            if ((dict.ContainsKey(doll) && dict.ContainsKey(woodenTrain))
                || (dict.ContainsKey(teddyBear) && dict.ContainsKey(bicycle)))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (stackWithMatirials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", stackWithMatirials)}");
            }

            if (ququesWithMagic.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", ququesWithMagic)}");
            }

            if (dict.Any())
            {
                foreach (var (toyName, amount) in dict.OrderBy(m => m.Key))
                {
                    Console.WriteLine($"{toyName}: {amount}");
                }
            }
        }

        private static void CraftPresent(Stack<int> stackWithMatirials,
            Queue<int> ququesWithMagic,
            int matirial,
            int product)
        {
            switch (product)
            {
                case DOLL_MAGIC_NEEDED_VALUE:

                    if (!dict.ContainsKey(doll))
                    {
                        dict[doll] = 0;
                    }
                    dict[doll]++;
                    RemoveItemsFromTheCollection(stackWithMatirials, ququesWithMagic);
                    break;
                case WOODEN_TRAIN_MAGIC_NEEDED_VALUE:

                    if (!dict.ContainsKey(woodenTrain))
                    {
                        dict[woodenTrain] = 0;
                    }
                    dict[woodenTrain]++;
                    RemoveItemsFromTheCollection(stackWithMatirials, ququesWithMagic);
                    break;
                case TEDDY_BEAR_MAGIC_NEEDED_VALUE:

                    if (!dict.ContainsKey(teddyBear))
                    {
                        dict[teddyBear] = 0;
                    }
                    dict[teddyBear]++;
                    RemoveItemsFromTheCollection(stackWithMatirials, ququesWithMagic);
                    break;
                case BICYCLE_MAGIC_NEEDED_VALUE:

                    if (!dict.ContainsKey(bicycle))
                    {
                        dict[bicycle] = 0;
                    }
                    dict[bicycle]++;
                    RemoveItemsFromTheCollection(stackWithMatirials, ququesWithMagic);
                    break;
                default:
                    RemoveItemsFromTheCollection(stackWithMatirials, ququesWithMagic);
                    stackWithMatirials.Push(matirial + 15);
                    break;
            }
        }

        private static void RemoveItemsFromTheCollection(Stack<int> stackWithMatirials, Queue<int> ququesWithMagic)
        {
            stackWithMatirials.Pop();
            ququesWithMagic.Dequeue();
        }
    }
}
