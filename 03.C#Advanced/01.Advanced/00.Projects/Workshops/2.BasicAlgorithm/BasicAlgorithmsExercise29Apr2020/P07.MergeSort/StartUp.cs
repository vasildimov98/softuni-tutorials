using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.MergeSort
{
    class StartUp
    {
        static void Main()
        {
            var input = Console
                 .ReadLine();

            if (input == string.Empty)
            {
                throw new InvalidOperationException("Array is empty!");
            }

            var arr = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Mergesort<int>.Sort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

    }
}
