using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|%$.]*?(?<price>[+-]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";

            double totalIncome = 0;

            string input = "";
            while ((input = Console.ReadLine()) != "end of shift")
            {

                if (Regex.IsMatch(input, regex))
                {
                    Match match = Regex.Match(input, regex, RegexOptions.IgnoreCase);
                    string customer = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    int count = int.Parse(match.Groups["count"].Value);
                    double price = double.Parse(match.Groups["price"].Value);

                    double totalPrice = count * price;

                    Console.WriteLine($"{customer}: {product} - {totalPrice:F2}");

                    totalIncome += totalPrice;
                }
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
