
namespace P01.CableMerchant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<int> prices;
        private static int connectorPrice;
        private static int[] bestPrices;
        static void Main()
        {
            ReadInput();
            CalculateBestPrices();
        }

        private static void CalculateBestPrices()
        {
            bestPrices = new int[prices.Count];

            for (int length = 1; length < prices.Count; length++)
            {
                var currLengthBestPrice = CudCableToFindBestPrice(length);

                Console.Write(currLengthBestPrice + " ");
            }

            Console.WriteLine();
        }

        private static int CudCableToFindBestPrice(int length)
        {
            if (length == 0) return 0;

            if (bestPrices[length] != 0) return bestPrices[length];

            var bestPrice = prices[length];

            for (int i = 1; i < length; i++)
            {
                var currBestPrice = prices[i] + CudCableToFindBestPrice(length - i) - 2 * connectorPrice;

                if (currBestPrice > bestPrice)
                    bestPrice = currBestPrice;
            }

            bestPrices[length] = bestPrice;

            return bestPrice;
        }

        private static void ReadInput()
        {
            prices = ReadPrices();
            connectorPrice = int.Parse(Console.ReadLine());
        }

        private static List<int> ReadPrices()
        {
            var pricesOutput = new List<int> { 0 };

            pricesOutput
                    .AddRange(Console
                        .ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .AsEnumerable());

            return pricesOutput;
        }
    }
}
