using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var data = Console
                 .ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            var n = data[0];
            var s = data[1];
            var x = data[2];

            var arr = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            PushElements(n, arr, stack);
            PopElements(s, stack);

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Count > 0 ? stack.Min() : 0);
            }
        }

        private static void PopElements(int s, Stack<int> stack)
        {
            for (int i = 0; i < s; i++)
            {
                if (stack.Any())
                {
                    stack.Pop();
                }
            }
        }

        private static void PushElements(int n, int[] arr, Stack<int> stack)
        {
            for (int i = 0; i < n; i++)
            {
                stack.Push(arr[i]);
            }
        }
    }
}
