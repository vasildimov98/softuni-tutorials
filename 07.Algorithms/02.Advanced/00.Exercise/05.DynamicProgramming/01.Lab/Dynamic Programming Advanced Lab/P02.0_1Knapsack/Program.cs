namespace P02._0_1Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Item 
    {
        public Item(string name, int weight, int value)
        {
            this.Name = name;
            this.Weight = weight;
            this.Value = value;
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }

    class Program
    {
        private static List<Item> items;
        private static int maxCapacity;

        private static int[,] greatestValue;
        private static SortedSet<string> takenItems;
        private static int totalWeight;
        static void Main()
        {
            ReadInput();
            Solve();
            BacktrackTakenItem();
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {greatestValue[items.Count, maxCapacity]}");
            Console.WriteLine(string.Join(Environment.NewLine, takenItems));
        }

        private static void BacktrackTakenItem()
        {
            takenItems = new SortedSet<string>();

            var row = items.Count;
            var col = maxCapacity;

            while (row > 0 && col > 0)
            {
                if (greatestValue[row, col] != greatestValue[row - 1, col])
                {
                    var currItem = items[row - 1];
                    takenItems.Add(currItem.Name);

                    col -= currItem.Weight;
                    totalWeight += currItem.Weight;
                }

                row--;
            }
        }

        private static void Solve()
        {
            var rows = items.Count + 1;
            var cols = maxCapacity + 1;
            greatestValue = new int[rows, cols];

            for (int row = 1; row < greatestValue.GetLength(0); row++)
            {
                var currItem = items[row - 1];
                for (int capacity = 1; capacity < greatestValue.GetLength(1); capacity++)
                {
                    var skipItem = greatestValue[row - 1, capacity];
                    if (currItem.Weight > capacity)
                    {
                        greatestValue[row, capacity] = skipItem;
                    }
                    else
                    {
                        var takeItem = currItem.Value + greatestValue[row - 1, capacity - currItem.Weight];

                        greatestValue[row, capacity] = Math.Max(skipItem, takeItem);
                    }
                }
            }
        }

        private static void ReadInput()
        {
            maxCapacity = int.Parse(Console.ReadLine());
            items = ReadItems();
        }

        private static List<Item> ReadItems()
        {
            var outputItems = new List<Item>();

            var finishLine = "end";

            string line;
            while ((line = Console.ReadLine()) != finishLine)
            {
                var itemArgs = line
                    .Split()
                    .ToArray();

                var item = new Item(itemArgs[0], int.Parse(itemArgs[1]), int.Parse(itemArgs[2]));

                outputItems.Add(item);
            }

            return outputItems;
        }
    }
}
