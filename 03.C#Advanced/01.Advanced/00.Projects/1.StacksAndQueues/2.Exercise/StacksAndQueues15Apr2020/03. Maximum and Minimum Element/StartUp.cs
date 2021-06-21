using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            var maxs = new Stack<int>();
            maxs.Push(int.MinValue);

            var mins = new Stack<int>();
            mins.Push(int.MaxValue);

            for (int i = 0; i < lines; i++)
            {
                var data = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (data[0] == 1)
                {
                    stack.Push(data[1]);

                    if (data[1] > maxs.Peek())
                    {
                        maxs.Push(data[1]);
                    }

                    if (data[1] < mins.Peek())
                    {
                        mins.Push(data[1]);
                    }
                }
                else if (data[0] == 2)
                {
                    if (!stack.Any())
                    {
                        continue;
                    }

                    var element = stack.Pop();

                    if (element == maxs.Peek())
                    {
                        maxs.Pop();
                    }

                    if (element == mins.Peek())
                    {
                        mins.Pop();
                    }
                }
                else if (data[0] == 3)
                {
                    if (!stack.Any())
                    {
                        continue;
                    }

                    Console.WriteLine(maxs.Peek());
                }
                else if (data[0] == 4)
                {
                    if (!stack.Any())
                    {
                        continue;
                    }

                    Console.WriteLine(mins.Peek());
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
