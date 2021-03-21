using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01.SpaceshipCrafting
{
    class StartUp
    {
        private const int GLASS_VALUE = 25;
        private const int ALUMINIUM_VALUE = 50;
        private const int LITHIUM_VALUE = 75;
        private const int CARBON_FIBER_VALUE = 100;

        private static int glassCount;
        private static int aluminiumCount;
        private static int lithiumCount;
        private static int carbonFiberCount;
        static void Main()
        {
            var inputChemicalLiquids = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var inputPhysicalItems = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var chemicalLiquids = new Queue<int>(inputChemicalLiquids);
            var physicalItems = new Stack<int>(inputPhysicalItems);

            while (chemicalLiquids.Count > 0 && physicalItems.Count > 0)
            {
                var currLiquid = chemicalLiquids.Dequeue();
                var currItem = physicalItems.Pop();

                var sumOfLiquidAndItem = currLiquid + currItem;

                LookForAdvanceMatirial(physicalItems, currItem, sumOfLiquidAndItem);
            }

            if (glassCount > 0
                && aluminiumCount > 0
                && lithiumCount > 0
                && carbonFiberCount > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            var liquidsToString = chemicalLiquids
                .Count > 0
                ? String.Join(", ", chemicalLiquids)
                : "none";

            Console.WriteLine($"Liquids left: {liquidsToString}");

            var itemsToString = physicalItems
               .Count > 0
               ? String.Join(", ", physicalItems)
               : "none";

            Console.WriteLine($"Physical items left: {itemsToString}");

            var sb = new StringBuilder();

            sb.AppendLine($"Aluminium: {aluminiumCount}");
            sb.AppendLine($"Carbon fiber: {carbonFiberCount}");
            sb.AppendLine($"Glass: {glassCount}");
            sb.Append($"Lithium: {lithiumCount}");

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void LookForAdvanceMatirial(Stack<int> physicalItems, int currItem, int sumOfLiquidAndItem)
        {
            switch (sumOfLiquidAndItem)
            {
                case GLASS_VALUE:
                    glassCount++;
                    break;
                case ALUMINIUM_VALUE:
                    aluminiumCount++;
                    break;
                case LITHIUM_VALUE:
                    lithiumCount++;
                    break;
                case CARBON_FIBER_VALUE:
                    carbonFiberCount++;
                    break;
                default:
                    physicalItems.Push(currItem + 3);
                    break;
            };
        }
    }
}
