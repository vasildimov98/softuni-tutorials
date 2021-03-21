using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> arr = Console
                .ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            ReadNewList(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        static List<double> ReadNewList(List<double> arr)
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    arr[i] += arr[i + 1];
                    arr.RemoveAt(i + 1);
                    i = -1;
                }
            }
            return arr;
        }

    }
}
