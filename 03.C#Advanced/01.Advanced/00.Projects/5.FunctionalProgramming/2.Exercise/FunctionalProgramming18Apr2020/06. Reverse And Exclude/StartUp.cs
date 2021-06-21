using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class StartUp
    {
        static void Main()
        {
            var list = Console
                .ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var divisor = int.Parse(Console.ReadLine());

            Func<int, bool> predicate = x => x % divisor != 0;

            Func<List<int>, List<int>> reverser = list =>
            {
                for (int i = 0; i < list.Count / 2; i++)
                {
                    var temp = list[i];
                    list[i] = list[list.Count - 1 - i];
                    list[list.Count - 1 - i] = temp;
                }

                return list;
            };

            Console.WriteLine(string.Join(" ", reverser(list
                .Where(predicate)
                .ToList())));
        }
    }
}
