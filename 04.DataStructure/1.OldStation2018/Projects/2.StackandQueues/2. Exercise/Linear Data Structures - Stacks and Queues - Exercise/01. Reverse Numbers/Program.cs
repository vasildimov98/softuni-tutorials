using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console
                .ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                int number = input[i];
                stack.Push(number);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{stack.Pop()} ");
            }
        }
    }
}
