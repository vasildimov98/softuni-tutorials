namespace P03.SumWithUnlimitedCoins
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var coins = Console
                .ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var target = int.Parse(Console.ReadLine());

            var targetCount = GetTargetCount(coins, target);

            Console.WriteLine(targetCount);
        }

        private static int GetTargetCount(int[] coins, int target)
        {
            var sumsByCount = new int[target + 1];
            sumsByCount[0] = 1;

            foreach (var coin in coins)
            {
                for (int sum = coin; sum < sumsByCount.Length; sum++)
                {
                    sumsByCount[sum] += sumsByCount[sum - coin];
                }
            }

            return sumsByCount[target];
        }
    }
}
