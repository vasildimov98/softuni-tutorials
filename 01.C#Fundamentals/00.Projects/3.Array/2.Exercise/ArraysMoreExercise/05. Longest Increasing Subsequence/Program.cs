using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] len = new int[nums.Length];
            int[] prev = new int[nums.Length];

            int maxLen = 0;
            int lastIndex = -1;
            for (int x = 0; x < nums.Length; x++)
            {
                len[x] = 1;
                prev[x] = -1;

                for (int i = 0; i < x; i++)
                {
                    if ((nums[i] < nums[x]) && (len[i] + 1 > len[x]))
                    {
                        len[x] = 1 + len[i];
                        prev[x] = i;
                    }
                }

                if (len[x] > maxLen)
                {
                    maxLen = len[x];
                    lastIndex = x;
                }
            }

            List<int> bestSeq = GetBestSeq(nums, prev, ref lastIndex);

            Console.WriteLine(string.Join(" ", bestSeq));
        }

        private static List<int> GetBestSeq(int[] nums, int[] prev, ref int lastIndex)
        {
            List<int> bestSeq = new List<int>();

            while (lastIndex != -1)
            {
                bestSeq.Add(nums[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            bestSeq.Reverse();
            return bestSeq;
        }
    }
}
