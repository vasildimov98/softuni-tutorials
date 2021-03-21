namespace P12.Needles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var sortedArray = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var needles = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var indexes = new List<int>();

            FindAllIndexes(sortedArray, needles, indexes);

            Console.WriteLine(string.Join(" ", indexes));
        }

        private static void FindAllIndexes(int[] sortedArray, int[] needles, List<int> indexes)
        {
            foreach (var needle in needles)
            {
                var match = false;
                for (int i = 0; i < sortedArray.Length; i++)
                {
                    if (sortedArray[i] >= needle)
                    {
                        match = true;
                        indexes.Add(FindPlaceToInsert(sortedArray, i));
                        break;
                    }
                }

                if (!match)
                {
                    indexes.Add(FindPlaceToInsert(sortedArray, sortedArray.Length));
                }
            }
        }

        private static int FindPlaceToInsert(int[] sortedArray, int i)
        {
            while (i > 0)
            {
                if (sortedArray[i - 1] != 0)
                    return i;

                i--;
            }

            return 0;
        }
    }
}
