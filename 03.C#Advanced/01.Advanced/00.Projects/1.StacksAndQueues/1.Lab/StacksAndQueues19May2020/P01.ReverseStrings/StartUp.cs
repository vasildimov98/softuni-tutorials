namespace P01.ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>(input);

            Console.WriteLine(string.Join("", stack));
        }
    }
}
