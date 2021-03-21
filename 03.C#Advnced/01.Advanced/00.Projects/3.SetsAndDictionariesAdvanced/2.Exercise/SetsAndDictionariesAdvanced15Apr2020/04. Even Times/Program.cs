using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<int, int>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(number))
                {
                    dict[number] = 0;
                }

                dict[number]++;
            }

            var kvp = dict.First(kvp => kvp.Value % 2 == 0);

            Console.WriteLine(kvp.Key);
        }
    }
}
