namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        static void Main()
        {
            var bagCapacity = long.Parse(Console.ReadLine());

            var bag = new Bag(bagCapacity);

            var tressure = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            ProcessBag(bag, tressure);

            Console.WriteLine(bag.ToString());
        }

        private static void ProcessBag(Bag bag, string[] tressure)
        {
            for (int i = 0; i < tressure.Length; i += 2)
            {
                var type = tressure[i];
                var amount = long.Parse(tressure[i + 1]);

                var tempType = type.ToLower();
                if (tempType.Length == 3)
                {
                    var currCashAmount = bag.CurrentCashAmount();
                    var currGemAmount = bag.CurrentGemAmount();

                    if (currCashAmount + amount <= currGemAmount)
                    {
                        bag.AddCash(new Cash(type, amount));
                    }
                }
                else if (tempType.EndsWith("gem"))
                {
                    var currGemAmount = bag.CurrentGemAmount();
                    var currGoldAmount = bag.CurrentGoldAmount();

                    if (currGemAmount + amount <= currGoldAmount)
                    {
                        bag.AddGem(new Gem(type, amount));
                    }
                }
                else if (tempType == "gold")
                {
                    bag.AddGold(new Gold(type, amount));
                }
            }
        }
    }
}