namespace P03.ProductShop
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        private static SortedDictionary<string, Dictionary<string, double>> shopsInfo;
        public static void Main()
        {
            shopsInfo = new SortedDictionary<string, Dictionary<string, double>>();

            GetShopsInformation();

            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var (shop, products) in shopsInfo)
            {
                Console.WriteLine($"{shop}->");

                foreach (var (product, price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }

        private static void GetShopsInformation()
        {
            string command;
            while ((command = Console.ReadLine()) != "Revision")
            {
                var shopArgs = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var shopName = shopArgs[0];
                var productName = shopArgs[1];
                var productPrice = double.Parse(shopArgs[2]);

                if (!shopsInfo.ContainsKey(shopName))
                {
                    shopsInfo[shopName] = new Dictionary<string, double>();
                }

                if (!shopsInfo[shopName].ContainsKey(productName))
                {
                    shopsInfo[shopName][productName] = 0;
                }

                shopsInfo[shopName][productName] += productPrice;
            }
        }
    }
}
