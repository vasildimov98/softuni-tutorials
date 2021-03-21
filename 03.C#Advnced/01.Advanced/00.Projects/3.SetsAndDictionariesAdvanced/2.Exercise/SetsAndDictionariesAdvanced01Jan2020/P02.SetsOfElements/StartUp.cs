namespace P02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static HashSet<string> firstSet;
        private static HashSet<string> secondSet;
        public static void Main()
        {
            firstSet = new HashSet<string>();
            secondSet = new HashSet<string>();

            var numbersOfElementsArgs = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstCountOfElements = numbersOfElementsArgs[0];
            var secondCountOfElements = numbersOfElementsArgs[1];

            GetSetsFilled(firstSet, firstCountOfElements);
            GetSetsFilled(secondSet, secondCountOfElements);

            PrintResult();
        }

        private static void PrintResult()
        {
            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }

        private static void GetSetsFilled(HashSet<string> set, int times)
        {
            for (int i = 0; i < times; i++)
            {
                set.Add(Console.ReadLine());
            }
        }
    }
}
