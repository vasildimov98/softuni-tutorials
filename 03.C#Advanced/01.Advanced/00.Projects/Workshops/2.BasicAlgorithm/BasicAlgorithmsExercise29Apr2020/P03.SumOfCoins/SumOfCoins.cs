using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 3, 7 };
        var targetSum = 11;
        try
        {
            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }
        catch (Exception)
        {

            throw new InvalidOperationException();
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var chosenCoins = new Dictionary<int, int>();

        var orderedCoins = coins
             .OrderByDescending(c => c)
             .ToList();

        foreach (var coin in orderedCoins)
        {
            var possibleCombination = targetSum / coin; // 18 

            targetSum %= coin;

            if (possibleCombination != 0)
            {
                chosenCoins[coin] = possibleCombination;
            }
        }

        if (targetSum == 0)
        {
            return chosenCoins;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}