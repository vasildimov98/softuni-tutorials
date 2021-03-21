using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            list = GetNewList(list);

            Console.WriteLine(string.Join(" ", list));
        }

        static List<int> GetNewList(List<int> list)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < list.Count / 2; i++)
            {
                result.Add(list[i] + list[list.Count - 1 - i]);
            }

            if (list.Count % 2 != 0)
            {
                result.Add(list[list.Count / 2]);
            }
            return result;
        }
    }
}
