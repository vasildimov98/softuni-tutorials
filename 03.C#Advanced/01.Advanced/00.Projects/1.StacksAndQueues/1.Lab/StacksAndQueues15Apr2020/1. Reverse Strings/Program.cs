using System;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>(input);

            Console.WriteLine(string.Join(string.Empty, stack));
        }
    }
}
