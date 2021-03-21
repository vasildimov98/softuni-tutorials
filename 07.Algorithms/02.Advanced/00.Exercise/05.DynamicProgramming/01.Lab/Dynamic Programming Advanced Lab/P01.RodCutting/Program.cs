using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.RodCutting
{
    class Program
    {
        private static int[] prices;
        private static int[] bestPrices;
        private static int[] bestCombos;
        private static int initialLength;
        static void Main()
        {
            ReadInput();
            //var bestPrice = FindBestPrice(initialLength);
            var bestPriceIter = FindBestPriceIter(initialLength);
            PrintResult(bestPriceIter);
        }

        private static int FindBestPriceIter(int initialLength)
        {
            for (int i = 1; i <= initialLength; i++)
            {
                var bestPrice = prices[i];
                var bestCombo = i;

                for (int j = 1; j < i; j++)
                {
                    if (bestPrices[j] + bestPrices[i - j] > bestPrice)
                    {
                        bestPrice = bestPrices[j] + bestPrices[i - j];
                        bestCombo = j;
                    }
                }

                bestPrices[i] = bestPrice;
                bestCombos[i] = bestCombo;
            }

            return bestPrices[initialLength];
        }

        private static void PrintResult(int bestPrice)
        {
            Console.WriteLine(bestPrice);
            Console.WriteLine(string.Join(" ", ReconstructCombo()));
        }

        private static List<int> ReconstructCombo()
        {
            var result = new List<int>();

            var length = initialLength;
            while (length != 0)
            {
                result.Add(bestCombos[length]);
                length -= bestCombos[length];
            }

            return result;
        }

        private static int FindBestPrice(int currLength)
        {
            if (currLength == 0) return 0;

            if (bestPrices[currLength] != 0) return bestPrices[currLength];

            var bestPrice = prices[currLength];
            var bestCombo = currLength;
            for (int i = 1; i < currLength; i++)
            {
                var currPrice = prices[i] + FindBestPrice(currLength - i);

                if (currPrice > bestPrice)
                {
                    bestPrice = currPrice;
                    bestCombo = i;
                }
            }

            bestPrices[currLength] = bestPrice;
            bestCombos[currLength] = bestCombo;
            return bestPrice;
        }

        private static void ReadInput()
        {
            prices = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            initialLength = int.Parse(Console.ReadLine());
            bestPrices = new int[initialLength + 1];
            bestCombos = new int[initialLength + 1];
        }
    }
}
