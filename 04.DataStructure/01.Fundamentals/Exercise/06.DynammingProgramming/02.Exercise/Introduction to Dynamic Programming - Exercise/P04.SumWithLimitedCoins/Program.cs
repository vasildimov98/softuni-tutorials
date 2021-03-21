namespace P04.SumWithLimitedCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var coins = Console
                .ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var target = int.Parse(Console.ReadLine());

            var count = GetTargerCoint(coins, target);

            Console.WriteLine(count);
        }

        private static int GetTargerCoint(int[] coins, int target)
        {
            var sums = new HashSet<int> { 0 };
            var count = 0;
            foreach (var coin in coins)
            {
                var currSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = sum + coin;
                    currSums.Add(newSum);
                    if (newSum == target) count++;
                }

                sums.UnionWith(currSums);
            }

            return count;
        }
    }
}
