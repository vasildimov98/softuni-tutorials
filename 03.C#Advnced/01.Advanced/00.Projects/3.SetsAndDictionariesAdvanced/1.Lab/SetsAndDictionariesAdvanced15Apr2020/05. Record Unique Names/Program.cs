using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var hashSet = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                hashSet.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, hashSet));
        }
    }
}
