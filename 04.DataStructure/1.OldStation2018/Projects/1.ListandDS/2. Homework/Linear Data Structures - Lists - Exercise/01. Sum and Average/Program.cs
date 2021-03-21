using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sum_and_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console
                .ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            int sum = 0;
            double average = 0;

            if (list.Any())
            {
                sum = list.Sum();
                average = list.Average();
            }

            Console.WriteLine($"Sum={sum}; Average={average:F2}");
        }
    }
}
