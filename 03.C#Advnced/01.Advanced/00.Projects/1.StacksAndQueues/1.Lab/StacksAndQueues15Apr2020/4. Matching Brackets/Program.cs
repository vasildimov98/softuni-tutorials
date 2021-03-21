using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if(input[i] == ')')
                {
                    var startOfOpenBasket = stack.Pop();

                    var result = input.Substring(startOfOpenBasket, i - startOfOpenBasket + 1);

                    Console.WriteLine(result);
                }
            }
        }
    }
}
