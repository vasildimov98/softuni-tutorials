namespace P03.RoadTrip
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Item
    {
        public int Value { get; set; }

        public int Weight { get; set; }
    }

    public class Program
    {
        private static List<Item> items;
        private static int maximumCapacity;

        public static void Main()
        {
            ReadInput();
        }

        private static void ReadInput()
        {
            var valueInfo = ReadArr();
            var weightInfo = ReadArr();

            maximumCapacity = int.Parse(Console.ReadLine());

            items = ReadItems(valueInfo, weightInfo);

            Console.WriteLine($"Maximum value: {CalculateMaxValue()}");
        }

        private static int CalculateMaxValue()
        {
            var maxValue = new int[items.Count + 1, maximumCapacity + 1];

            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var currItem = items[itemIndex];

                for (int currCapacity = 1; currCapacity < maximumCapacity + 1; currCapacity++)
                {
                    var excludeItem = maxValue[itemIndex, currCapacity];

                    if (currItem.Weight > currCapacity)
                    {
                        maxValue[itemIndex + 1, currCapacity] = excludeItem;
                        continue;
                    }

                    var includeItem = currItem.Value + maxValue[itemIndex, currCapacity - currItem.Weight];

                    maxValue[itemIndex + 1, currCapacity] = Math.Max(includeItem, excludeItem);
                }
            }

            return maxValue[items.Count, maximumCapacity];
        }

        private static List<Item> ReadItems(int[] valueInfo, int[] weightInfo)
        {
            var output = new List<Item>();

            for (int i = 0; i < valueInfo.Length; i++)
            {
                var newItem = new Item
                {
                    Value = valueInfo[i],
                    Weight = weightInfo[i]
                };

                output.Add(newItem);
            }

            return output;
        }

        private static int[] ReadArr()
        {
            return Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
        }
    }
}
