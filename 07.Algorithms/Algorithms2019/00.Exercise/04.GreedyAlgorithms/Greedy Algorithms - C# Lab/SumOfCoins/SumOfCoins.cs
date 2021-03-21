namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main()
        {
            var availableCoins = new[] { 3, 7 };
            var targetSum = 11;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var selectedCoins = new Dictionary<int, int>();

            coins = coins
                .OrderByDescending(x => x)
                .ToList();

            var currCoinIndex = 0;

            while (currCoinIndex < coins.Count && targetSum != 0)
            {
                var currCoin = coins[currCoinIndex++];

                if (currCoin > targetSum) continue;

                var coinTimesInTargetSum = targetSum / currCoin;

                targetSum -= currCoin * coinTimesInTargetSum;

                selectedCoins[currCoin] = coinTimesInTargetSum;
            }

            if (targetSum != 0)
                throw new InvalidOperationException("Target sum is unreachable with this set of coins!");

            return selectedCoins;
        }
    }
}