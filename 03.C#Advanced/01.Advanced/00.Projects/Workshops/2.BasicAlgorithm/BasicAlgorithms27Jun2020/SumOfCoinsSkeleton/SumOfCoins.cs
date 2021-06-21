using System;
using System.Collections.Generic;
using System.Linq;
public class SumOfCoins
{
    public static void Main()
    {
        var availableCoins = Console
            .ReadLine()
            .Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries)
            .ToArray()[1]
            .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        var targetSum = int.Parse(Console
            .ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray()[1]);

        try
        {
            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }
        catch (InvalidOperationException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var sellectedCoins = new Dictionary<int, int>();

        var orderedCoins = coins
            .OrderByDescending(c => c)
            .ToArray();

        foreach (var coin in orderedCoins)
        {
            var collectedCoins = targetSum / coin;

            if (targetSum == 0)
            {
                break;
            }

            if (collectedCoins > 0)
            {
                targetSum %= coin;
                sellectedCoins[coin] = collectedCoins;
            }
        }

        if (targetSum != 0)
        {
            throw new InvalidOperationException("Error");
        }

        return sellectedCoins;
    }
}