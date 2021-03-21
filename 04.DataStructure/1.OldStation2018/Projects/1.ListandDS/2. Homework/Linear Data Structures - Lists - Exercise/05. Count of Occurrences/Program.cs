using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_of_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console
            .ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

            SortedDictionary<int, int> keyValuePairs = new SortedDictionary<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (!keyValuePairs.ContainsKey(list[i]))
                {
                    keyValuePairs[list[i]] = 0;
                }
                keyValuePairs[list[i]]++;
            }

            foreach (var num in keyValuePairs)
            {
                Console.WriteLine($"{num.Key} -> {num.Value} times");
            }
        }
    }
}
