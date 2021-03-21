using System;
using System.Linq;

namespace _04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console
                 .ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            int[] sorted = arr
                .OrderByDescending(a => a)
                .ToArray();

            string result = "";
            if (arr.Length < 3)
            {
                Console.WriteLine(string.Join(" ", sorted));
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    result += sorted[i] + " ";
                }
            }

            Console.WriteLine(result);
        }
    }
}
