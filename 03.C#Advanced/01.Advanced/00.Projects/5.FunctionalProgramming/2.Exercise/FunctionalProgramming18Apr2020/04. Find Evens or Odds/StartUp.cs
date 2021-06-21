using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class StartUp
    {
        static void Main()
        {
            var bounders = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lowerBound = bounders[0];
            var upperBound = bounders[1];

            string query = Console.ReadLine();

            Predicate<int> filter = query == "odd" ?
            new Predicate<int>(x => x % 2 != 0) :
            new Predicate<int>(x => x % 2 == 0);

            var list = new List<int>();
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (filter(i))
                {
                    list.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
