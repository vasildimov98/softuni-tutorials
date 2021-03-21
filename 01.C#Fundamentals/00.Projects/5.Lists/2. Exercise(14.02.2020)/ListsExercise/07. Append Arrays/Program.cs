using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console
                .ReadLine()
                .Split("|")
                .ToList();

            List<int> finalList = new List<int>();

            for (int i = list.Count -1; i >= 0; i--)
            {
                List<string> list1 = list[i]
                .Split()
                .ToList();

                for (int index = 0; index < list1.Count; index++)
                {
                    if (list1[index] != "")
                    {
                        finalList.Add(int.Parse(list1[index]));
                    }
                }
            }

            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}
