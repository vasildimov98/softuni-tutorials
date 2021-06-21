namespace P06.Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<string, Dictionary<string, int>> wardrobe;
        public static void Main()
        {
            wardrobe = new Dictionary<string, Dictionary<string, int>>();

            var numberOfCommands = int.Parse(Console.ReadLine());

            OrganizetheWardrobe(numberOfCommands);

            var lastCommand = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var color = lastCommand[0];
            var clothing = lastCommand[1];

            PrintTheWardrobe(color, clothing);
        }

        private static void PrintTheWardrobe(string color, string clothing)
        {
            foreach (var (typeOfColor, clothes) in wardrobe)
            {
                Console.WriteLine($"{typeOfColor} clothes:");

                foreach (var (clothe, count) in clothes)
                {
                    if (typeOfColor == color && clothe == clothing)
                    {
                        Console.WriteLine($"* {clothe} - {count} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {clothe} - {count}");
                }
            }
        }

        private static void OrganizetheWardrobe(int numberOfCommands)
        {
            for (int i = 0; i < numberOfCommands; i++)
            {
                var wardrobeArgs = Console
                    .ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var colorOfTheCloth = wardrobeArgs[0];

                if (!wardrobe.ContainsKey(colorOfTheCloth))
                {
                    wardrobe[colorOfTheCloth] = new Dictionary<string, int>();
                }

                var items = wardrobeArgs[1]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var cloth in items)
                {
                    if (!wardrobe[colorOfTheCloth].ContainsKey(cloth))
                    {
                        wardrobe[colorOfTheCloth][cloth] = 0;
                    }

                    wardrobe[colorOfTheCloth][cloth]++;
                }
            }
        }
    }
}
