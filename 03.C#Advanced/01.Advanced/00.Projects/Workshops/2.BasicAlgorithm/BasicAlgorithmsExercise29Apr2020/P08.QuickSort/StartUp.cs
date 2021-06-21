using System;
using System.Linq;

namespace P08.QuickSort
{
    class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine();

            if (input == string.Empty)
            {
                return;
            }

            var arr = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Quicksort.Sort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
