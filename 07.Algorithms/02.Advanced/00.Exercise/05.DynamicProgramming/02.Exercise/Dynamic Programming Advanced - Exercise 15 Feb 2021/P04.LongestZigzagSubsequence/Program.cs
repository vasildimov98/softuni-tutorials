namespace P04.LongestZigzagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int[] sequence;
        private static int[,] longestZigZagSubsequence;
        private static int[,] previousCol;

        private static int bestRow;
        private static int bestCol;
        public static void Main()
        {
            ReadInput();
            FindLongestZigZagSubsequence();
            PrintResul();
        }

        private static void PrintResul()
        {
            var path = ReconstructPath();
            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<int> ReconstructPath()
        {
            var output = new Stack<int>();

            while (bestCol != -1)
            {
                output.Push(sequence[bestCol]);
                bestCol = previousCol[bestRow, bestCol];

                if (bestRow == 1) bestRow = 0;
                else bestRow = 1;
            }

            return output;
        }

        private static void FindLongestZigZagSubsequence()
        {
            longestZigZagSubsequence = new int[2, sequence.Length];
            previousCol = new int[2, sequence.Length];
            var longestZigZagSequence = 0;

            for (int currInx = 0; currInx < sequence.Length; currInx++)
            {
                longestZigZagSubsequence[0, currInx] = 1;
                longestZigZagSubsequence[1, currInx] = 1;

                previousCol[0, currInx] = -1;
                previousCol[1, currInx] = -1;

                var currentNumber = sequence[currInx];

                for (int prevInx = currInx - 1; prevInx >= 0; prevInx--)
                {
                    var prevNumber = sequence[prevInx];

                    if (currentNumber < prevNumber
                        && longestZigZagSubsequence[1, prevInx] + 1 >= longestZigZagSubsequence[0, currInx])
                    {
                        longestZigZagSubsequence[0, currInx] = longestZigZagSubsequence[1, prevInx] + 1;
                        previousCol[0, currInx] = prevInx;
                    }

                    if (currentNumber > prevNumber
                        && longestZigZagSubsequence[0, prevInx] + 1 >= longestZigZagSubsequence[1, currInx])
                    {
                        longestZigZagSubsequence[1, currInx] = longestZigZagSubsequence[0, prevInx] + 1;
                        previousCol[1, currInx] = prevInx;
                    }
                }

                if (longestZigZagSubsequence[0, currInx] > longestZigZagSequence)
                {
                    longestZigZagSequence = longestZigZagSubsequence[0, currInx];
                    bestRow = 0;
                    bestCol = currInx;
                }

                if (longestZigZagSubsequence[1, currInx] > longestZigZagSequence)
                {
                    longestZigZagSequence = longestZigZagSubsequence[1, currInx];
                    bestRow = 1;
                    bestCol = currInx;
                }
            }
        }

        private static void ReadInput()
        {
            sequence = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
        }
    }
}
