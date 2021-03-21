using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> list2 = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> newList = GetNewList(list1, list2);

            Console.WriteLine(string.Join(" ", newList));
        }

        static List<int> GetNewList(List<int> list1, List<int> list2)
        {
            int count = Math.Max(list1.Count, list2.Count);

            List<int> newList = new List<int>();
            for (int i = 0; i < count; i++)
            {
                if (i < list1.Count)
                {
                    newList.Add(list1[i]);
                }

                if (i < list2.Count)
                {
                    newList.Add(list2[i]);
                }
            }

            return newList;
        }
    }
}
