using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] data = command.Split();

                string product = data[0];
                double price = double.Parse(data[1]);
                double quatity = double.Parse(data[2]);

                if (!dict.ContainsKey(product))
                {
                    dict.Add(product, new List<double>());
                    dict[product].Add(price);
                    dict[product].Add(quatity);
                }
                else
                {
                    quatity += dict[product][1];
                    dict[product][0] = price;
                    dict[product][1] = quatity;
                }
            }

            foreach (var item in dict)
            {
                double price = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {price:F2}");
            }
        }
    }
}
