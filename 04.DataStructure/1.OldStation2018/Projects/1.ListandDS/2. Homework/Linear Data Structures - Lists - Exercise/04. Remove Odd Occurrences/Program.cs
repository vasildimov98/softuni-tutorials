﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Remove_Odd_Occurrences
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

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (!keyValuePairs.ContainsKey(list[i]))
                {
                    keyValuePairs[list[i]] = 0;
                }
                keyValuePairs[list[i]]++;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (keyValuePairs[list[i]] % 2 == 0)
                {
                    Console.Write(list[i] + " ");
                }
            }
        }
    }
}
