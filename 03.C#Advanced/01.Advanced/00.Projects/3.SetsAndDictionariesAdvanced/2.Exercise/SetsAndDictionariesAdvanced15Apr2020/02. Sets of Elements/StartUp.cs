using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class StartUp
    {
        static void Main()
        {
            var data = Console
                 .ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            var n = data[0];
            var m = data[1];

            var firstSet = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            var unique = new HashSet<int>();
            for (int i = 0; i < m; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (firstSet.Contains(number))
                {
                    unique.Add(number);
                }
            }
            foreach (var el in firstSet)
            {
                if (unique.Contains(el))
                {
                    Console.Write(el + " ");
                }
            }
        }
    }
}
