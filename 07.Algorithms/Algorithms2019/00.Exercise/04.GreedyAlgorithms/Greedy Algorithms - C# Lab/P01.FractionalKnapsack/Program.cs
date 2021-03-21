namespace P01.FractionalKnapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Item
    {
        public double TotalPrice { get; set; }
        public double Weight { get; set; }
    }

    class Program
    {
        private static double capacity;
        private static List<Item> items;
        static void Main()
        {
            capacity = double
                      .Parse(Console
                      .ReadLine()
                      .Split()[1]);

            items = ReadItems();

            SolveProblem();
        }

        private static void SolveProblem()
        {
            var currItemIndex = 0;
            var totalPrice = 0.0;
            while (capacity > 0 && currItemIndex < items.Count)
            {
                var currItem = items[currItemIndex++];

                var quantityOfSelectedItem = Math.Min(currItem.Weight, capacity);

                capacity -= quantityOfSelectedItem;

                totalPrice += currItem.TotalPrice * quantityOfSelectedItem / currItem.Weight;

                var quantityToPercentage = quantityOfSelectedItem / currItem.Weight == 1 ? "100" : $"{quantityOfSelectedItem / currItem.Weight * 100:F2}";

                Console.WriteLine($"Take {quantityToPercentage}% of item with price {currItem.TotalPrice:F2} and weight {currItem.Weight:F2}");
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }

        private static List<Item> ReadItems()
        {
            var countOfItems = int
                .Parse(Console
                .ReadLine()
                .Split()[1]);

            var items = new List<Item>();
            for (int i = 0; i < countOfItems; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split()
                    .ToArray();

                items.Add(new Item
                {
                    TotalPrice = double.Parse(args[0]),
                    Weight = double.Parse(args[2])
                });
            }

            return items
                .OrderByDescending(i => i.TotalPrice / i.Weight)
                .ToList();
        }
    }
}
