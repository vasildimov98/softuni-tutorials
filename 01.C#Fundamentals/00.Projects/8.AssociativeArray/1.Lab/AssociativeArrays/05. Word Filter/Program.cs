using System;
using System.Linq;

namespace _05._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console
                .ReadLine()
                .Split()
                .Where(a => a.Length % 2 == 0)
                .ToArray();

            Console.WriteLine(string.Join("\n", words));
        }
    }
}
