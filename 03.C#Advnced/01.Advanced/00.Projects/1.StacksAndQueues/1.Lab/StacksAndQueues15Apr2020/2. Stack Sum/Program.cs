using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console
                 .ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            var stack = new Stack<int>(arr);

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                var data = command.Split();

                if (data[0] == "add")
                {
                    stack.Push(int.Parse(data[1]));
                    stack.Push(int.Parse(data[2]));
                }
                else if (data[0] == "remove")
                {
                    int totalElementsToRemove = int.Parse(data[1]);

                    if (stack.Count >= totalElementsToRemove)
                    {
                        for (int i = 0; i < totalElementsToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
