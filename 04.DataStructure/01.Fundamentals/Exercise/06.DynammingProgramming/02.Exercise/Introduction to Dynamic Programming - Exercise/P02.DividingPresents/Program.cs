namespace P02.DividingPresents
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var presents = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var presentSums = GetAllSumsOfPresents(presents);

            var totalPresentsSum = presents.Sum();
            var alanSum = GetAlanSum(presentSums, totalPresentsSum);
            var bobSum = totalPresentsSum - alanSum;

            var alanPresents = string.Join(" ", GetAlanPresents(presentSums, alanSum));
            PrintResult(alanSum, bobSum, alanPresents);
        }

        private static void PrintResult(int alanSum, int bobSum, string alanPresents)
        {
            Console.WriteLine($"Difference: {bobSum - alanSum}");
            Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
            Console.WriteLine($"Alan takes: {alanPresents}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> GetAlanPresents(Dictionary<int, int> presentSums, int target)
        {
            var alanPresents = new List<int>();
            
            while (target != 0)
            {
                var currPresent = presentSums[target];
                alanPresents.Add(currPresent);
                target -= currPresent;
            }

            return alanPresents;
        }

        private static int GetAlanSum(Dictionary<int, int> presentSum, int totalPresentsSum)
        {
            var currSum = totalPresentsSum / 2;

            while (!presentSum.ContainsKey(currSum)) currSum--;

            return currSum;
        }

        private static Dictionary<int, int> GetAllSumsOfPresents(int[] numbers)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in numbers)
            {
                var currSums = sums.Keys.ToArray();
                foreach (var sum in currSums)
                {
                    var newSum = sum + num;

                    if (!sums.ContainsKey(newSum))
                        sums[newSum] = num;
                }
            }

            return sums;
        }
    }
}
