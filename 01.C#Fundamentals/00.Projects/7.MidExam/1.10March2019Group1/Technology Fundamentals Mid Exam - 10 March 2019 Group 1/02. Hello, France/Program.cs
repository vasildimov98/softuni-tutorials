using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console
                .ReadLine()
                .Split("|");

            double budgets = double.Parse(Console.ReadLine());
            List<double> Prices = new List<double>();
            List<double> newPrices = new List<double>();

            for (int i = 0; i < arr.Length; i++)
            {
                string[] data = arr[i].Split("->");

                string product = data[0];
                double price = double.Parse(data[1]);

                if (product == "Clothes" && price <= 50.00 && budgets >= price)
                {
                    budgets -= price;
                    Prices.Add(price);
                    newPrices.Add(price*1.40);
                }
                else if (product == "Shoes" && price <= 35.00 && budgets >= price)
                {
                    budgets -= price;
                    Prices.Add(price);
                    newPrices.Add(price*1.40);
                }
                else if (product == "Accessories" && price <= 20.50 && budgets >= price)
                {
                    budgets -= price;
                    Prices.Add(price);
                    newPrices.Add(price*1.40);
                }
            }

            double profit = newPrices.Sum() - Prices.Sum();

            string result = "";
            foreach (var price in newPrices)
            {
                result += $"{price:F2} ";
            }

            Console.WriteLine(result);
            Console.WriteLine($"Profit: {profit:f2}");

            if (newPrices.Sum() + budgets >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
