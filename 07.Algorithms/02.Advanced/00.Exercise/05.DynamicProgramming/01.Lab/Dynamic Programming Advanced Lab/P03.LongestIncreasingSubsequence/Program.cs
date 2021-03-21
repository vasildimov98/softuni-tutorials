namespace P03.LongestIncreasingSubsequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        private static int[] sequence;
        private static int[] len;
        private static int[] prev;

        private static int bestLengthIndex;
        static void Main()
        {
            sequence = ReadInput();
            FindLongestCommonSubsequence();
            Console.WriteLine(string.Join(" ", BackTrackLongestSubsequence()));
        }

        private static Stack<int> BackTrackLongestSubsequence()
        {
            var outputLis = new Stack<int>();

            while (bestLengthIndex != -1)
            {
                outputLis.Push(sequence[bestLengthIndex]);
                bestLengthIndex = prev[bestLengthIndex];
            }

            return outputLis;
        }

        private static void FindLongestCommonSubsequence()
        {
            len = new int[sequence.Length];
            prev = new int[sequence.Length];

            var bestLength = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                prev[i] = -1;
                var currNum = sequence[i];
                var bestLen = 1;
                for (int j = i - 1; j >= 0; j--)
                {
                    var prevNum = sequence[j];

                    if (prevNum < currNum
                        && len[j] + 1 >= bestLen)
                    {
                        prev[i] = j;
                        bestLen = len[j] + 1;
                    }
                }

                len[i] = bestLen;

                if (bestLen > bestLength)
                {
                    bestLength = bestLen;
                    bestLengthIndex = i;
                }
            }
        }

        private static int[] ReadInput()
        {
            return Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
    }
}
