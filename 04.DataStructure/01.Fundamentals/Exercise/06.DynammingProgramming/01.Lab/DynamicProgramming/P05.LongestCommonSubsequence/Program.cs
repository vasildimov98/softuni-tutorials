namespace P05.LongestCommonSubsequence
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();
            var table = new int[str1.Length + 1, str2.Length + 1];

            FindLongestCommonSubSequence(table, str1, str2);

            var path = new Stack<char>();
            FindPathBackwards(path, table, str1, str2);
            Console.WriteLine(string.Join("", path));
        }

        private static void FindPathBackwards(Stack<char> path, int[,] table, string str1, string str2)
        {
            var row = str1.Length;
            var col = str2.Length;
            while (row > 0 && col > 0)
            {
                if (str1[row - 1] == str2[col - 1]
                    && table[row, col] == table[row - 1, col - 1] + 1)
                {
                    path.Push(str1[row - 1]);

                    row--;
                    col--;
                }
                else if (table[row - 1, col] > table[row, col - 1])
                    row--;
                else col--;
            }
        }

        private static void FindLongestCommonSubSequence(int[,] table, string str1, string str2)
        {
            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 1; col < table.GetLength(1); col++)
                {
                    var currLetterOfFirstStrng = str1[row - 1];
                    var currLetterOfSecondStrng = str2[col - 1];

                    if (currLetterOfFirstStrng == currLetterOfSecondStrng)
                        table[row, col] = table[row - 1, col - 1] + 1;
                    else table[row, col] = Math.Max(table[row, col - 1], table[row - 1, col]);
                }
            }
        }
    }
}
