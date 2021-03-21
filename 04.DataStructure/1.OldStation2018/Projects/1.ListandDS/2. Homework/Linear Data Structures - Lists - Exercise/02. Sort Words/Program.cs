using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sort_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console
                .ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            list.Sort();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
