using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class StartUp
    {
        static void Main()
        {
            /*
             {shop}->
Product: {product}, Price: {price}


            lidl, juice, 2.30
fantastico, apple, 1.20
kaufland, banana, 1.10
fantastico, grape, 2.20
Revision

             */

            string command;

            var sortedDict = new SortedDictionary<string, Dictionary<string, double>>();

            while ((command = Console.ReadLine()) != "Revision")
            {
                var data = command
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var shop = data[0];
                var product = data[1];
                var price = double.Parse(data[2]);

                if (!sortedDict.ContainsKey(shop))
                {
                    sortedDict[shop] = new Dictionary<string, double>();
                }

                if (!sortedDict[shop].ContainsKey(product))
                {
                    sortedDict[shop][product] = 0;
                }

                sortedDict[shop][product] += price;
            }

            foreach (var (shop, products) in sortedDict)
            {
                Console.WriteLine($"{shop}->");

                foreach (var (product, price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }

    }
}
