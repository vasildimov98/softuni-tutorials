using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var chemicalElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var chemicalEl = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var el in chemicalEl)
                {
                    chemicalElements.Add(el);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalElements));
        }
    }
}
