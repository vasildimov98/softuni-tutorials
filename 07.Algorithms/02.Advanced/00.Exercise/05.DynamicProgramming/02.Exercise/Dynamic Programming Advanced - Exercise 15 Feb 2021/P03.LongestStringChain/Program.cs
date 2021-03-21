namespace P03.LongestStringChain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static string[] words;
        private static int[] length;
        private static int[] previousIndex;
        static void Main()
        {
            ReadInput();
            var endIndex = FindLongestSubSequenceIndex(words);
            var path = ReconstructPath(endIndex);
            Console.WriteLine(string.Join(" ", path));
        }

        private static void ReadInput()
        {
            words = Console
                .ReadLine()
                .Split()
                .ToArray();

            length = new int[words.Length];
            previousIndex = new int[words.Length];
        }

        private static Stack<string> ReconstructPath(int endIndex)
        {
            var output = new Stack<string>();

            while (endIndex != -1)
            {
                output.Push(words[endIndex]);
                endIndex = previousIndex[endIndex];
            }

            return output;
        }

        private static int FindLongestSubSequenceIndex(string[] words)
        {
            var longestSubsequence = 0;
            var output = -1;

            for (int currIndx = 0; currIndx < words.Length; currIndx++)
            {
                previousIndex[currIndx] = -1;
                length[currIndx] = 1;

                var currentWordLen = words[currIndx].Length;

                for (int prevIndex = currIndx - 1; prevIndex >= 0; prevIndex--)
                {
                    var previousWord = words[prevIndex].Length;

                    if (currentWordLen > previousWord
                        && length[prevIndex] + 1 >= length[currIndx])
                    {
                        length[currIndx] = length[prevIndex] + 1;
                        previousIndex[currIndx] = prevIndex;
                    }
                }

                if (length[currIndx] > longestSubsequence)
                {
                    longestSubsequence = length[currIndx];
                    output = currIndx;
                }
            }

            return output;
        }
    }
}
