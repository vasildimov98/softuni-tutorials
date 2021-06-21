using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var value = Console.ReadLine();

                list.Add(value);
            }

            var indexes = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstIndex = indexes[0];
            var secondIndex = indexes[1];

            SwapElements(list, firstIndex, secondIndex);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }

        static void SwapElements<T>(List<T> list, int firstIndex, int secondIndex)
        {
            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
