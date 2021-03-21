using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
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

            int max = Math.Max(list1.Count, list2.Count);
            int firstElement = 0;
            int secondElement = 0;

            GetNewList(list1, list2, max, out firstElement, out secondElement);

            List<int> newList = new List<int>();
            for (int i = 0; i < list1.Count; i++)
            {
                int element1 = list1[i];
                int element2 = list2[list2.Count - 1 - i];

                if (element1 > firstElement && element1 < secondElement)
                {
                    newList.Add(element1);
                }

                if (element2 > firstElement && element2 < secondElement)
                {
                    newList.Add(element2);
                }
            }

            newList.Sort();

            Console.WriteLine(string.Join(" ", newList));
        }

        private static void GetNewList(List<int> list1, List<int> list2, int max, out int firstElement, out int secondElement)
        {
            if (max == list1.Count)
            {
                firstElement = list1[list1.Count - 2];
                secondElement = list1[list1.Count - 1];
                list1.RemoveRange(list1.Count - 2, 2);
                if (firstElement > secondElement)
                {
                    int temp = firstElement;
                    firstElement = secondElement;
                    secondElement = temp;
                }
            }
            else
            {
                firstElement = list2[0];
                secondElement = list2[1];
                list2.RemoveRange(0, 2);
                if (firstElement > secondElement)
                {
                    int temp = firstElement;
                    firstElement = secondElement;
                    secondElement = firstElement;
                }
            }
        }
    }
}
