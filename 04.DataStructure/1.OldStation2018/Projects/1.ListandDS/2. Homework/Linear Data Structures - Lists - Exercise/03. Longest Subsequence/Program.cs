using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Longest_Subsequence
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

            int maxNumber = 0;
            int maxCount = 0;

            for (int i = 0; i < list.Count; i++)
            {
                int count = 1;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] == list[i])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxNumber = list[i];
                }
            }

            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(maxNumber + " ");
            }
        }
    }
}
