using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var stack = new Stack<string>(input.Reverse());

            while (stack.Count > 1)
            {
                var firstNum = int.Parse(stack.Pop());
                var operation = stack.Pop();
                var secondNum = int.Parse(stack.Pop());

                var temResult = operation switch
                {
                    "+" => (firstNum + secondNum),
                    "-" => (firstNum - secondNum),
                    _ => 0
                };

                stack.Push(temResult.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
