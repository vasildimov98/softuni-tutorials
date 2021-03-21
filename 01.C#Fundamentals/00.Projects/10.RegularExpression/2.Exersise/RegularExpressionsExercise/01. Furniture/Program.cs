using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<product>[A-Za-z]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)";

            List<string> allPurchases = new List<string>();

            string purchase;
            double totalCost = 0;
            while ((purchase = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(purchase, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    var product = match.Groups["product"].Value;
                    allPurchases.Add(product);
                    double price = double.Parse(match.Groups["price"].Value);
                    double quant = double.Parse(match.Groups["quantity"].Value);

                    totalCost += price * quant;
                }
            }

            Console.WriteLine("Bought furniture:");
            if (allPurchases.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, allPurchases));
            }
            Console.WriteLine($"Total money spend: {totalCost:F2}");
        }
    }
}
