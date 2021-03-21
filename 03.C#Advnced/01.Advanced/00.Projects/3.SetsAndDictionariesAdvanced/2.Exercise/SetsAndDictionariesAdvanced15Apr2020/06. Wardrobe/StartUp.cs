using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class StartUp
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, Dictionary<string, int>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var color = Console
                    .ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var currColor = color[0];
                if (!dictionary.ContainsKey(currColor))
                {
                    dictionary[currColor] = new Dictionary<string, int>();
                }

                var clothes = color[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < clothes.Length; j++)
                {
                    var currClothe = clothes[j];

                    if (!dictionary[currColor].ContainsKey(currClothe))
                    {
                        dictionary[currColor][currClothe] = 0;
                    }

                    dictionary[currColor][currClothe]++;
                }
            }

            var data = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var colorToLookFor = data[0];
            var clothing = data[1];

            foreach (var (color, clothes) in dictionary)
            {

                Console.WriteLine($"{color} clothes:");
                if (color == colorToLookFor)
                {
                    foreach (var (clothe, count) in clothes)
                    {
                        if (clothe == clothing)
                        {
                            Console.WriteLine($"* {clothe} - {count} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {clothe} - {count}");
                        }

                    }
                }
                else
                {
                    foreach (var (clothe, count) in clothes)
                    {
                        Console.WriteLine($"* {clothe} - {count}");
                    }
                }
            }
        }
    }
}
