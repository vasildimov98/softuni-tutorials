namespace P04.FindEvensOrOdds
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var bounds = Console
                .ReadLine()
                .Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lowerBound = bounds[0];
            var upperBound = bounds[1];

            var condition = Console.ReadLine();

            var predicate = GetPredicate(condition);

            var list = new List<int>();

            GetPredicateNumbers(lowerBound, upperBound, predicate, list);

            Console.WriteLine(string.Join(" ", list));
        }

        private static void GetPredicateNumbers(int lowerBound, int upperBound, Predicate<int> predicate, List<int> list)
        {
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (predicate(i))
                {
                    list.Add(i);
                }
            }
        }

        private static Predicate<int> GetPredicate(string con)
        {
            if (con == "odd")
            {
                return n => n % 2 != 0;
            }
            else
            {
                return n => n % 2 == 0;
            }
        }
    }
}
