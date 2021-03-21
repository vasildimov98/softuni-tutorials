namespace P02.GenericSwapMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var list = new List<int>();
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());

                list.Add(input);
            }

            var swapIndexes = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstIndex = swapIndexes[0];
            var secondIndex = swapIndexes[1];

            Swap(list, firstIndex, secondIndex);

            list
                .ForEach(i => Console.WriteLine($"{i.GetType().FullName}: {i}"));
        }

        public static void Swap<T>(List<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
