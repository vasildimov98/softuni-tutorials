namespace P07.SumOfCoins
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    class StartUp
    {
        static void Main()
        {
            var coinsComb = Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var coins = new SortedSet<int>(coinsComb);

            var target = int.Parse(Console.ReadLine());

            var totalCountOfCoins = 0;
            var sb = new StringBuilder();
            while (target > 0
                && coins.Count > 0)
            {
                var maxCoin = coins.Max;
                coins.Remove(maxCoin);

                if (maxCoin > target) continue;

                var timesInTarget = target / maxCoin;
                target -= maxCoin * timesInTarget;

                totalCountOfCoins += timesInTarget;
                sb.AppendLine($"{timesInTarget} coin(s) with value {maxCoin}");
            }

            if (target > 0) Console.WriteLine("Error");
            else
            {
                Console.WriteLine($"Number of coins to take: {totalCountOfCoins}");
                Console.WriteLine(sb.ToString().Trim());
            }
        }
    }
}
