using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var data = ParseArray();

            var dict = new Dictionary<double, int>();

            for (int i = 0; i < data.Length; i++)
            {
                if (!dict.ContainsKey(data[i]))
                {
                    dict[data[i]] = 0;
                }

                dict[data[i]]++;
            }

            foreach (var (value, number) in dict)
            {
                Console.WriteLine($"{value} - {number} times");
            }
        }

        static double[] ParseArray()
        {
            return Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
        }
    }
}
