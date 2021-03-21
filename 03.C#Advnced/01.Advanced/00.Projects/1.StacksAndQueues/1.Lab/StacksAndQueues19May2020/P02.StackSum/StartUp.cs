namespace P02.StackSum
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var integerArr = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(integerArr);

            ProcessCommands(stack);

            Console.WriteLine($"Sum: {stack.Sum()}");
        }

        private static void ProcessCommands(Stack<int> stack)
        {
            string command;
            while ((command = Console.ReadLine()).ToLower() != "end")
            {
                var arg = command
                    .Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = arg[0].ToLower();

                if (action == "add")
                {
                    AddElements(stack, arg);
                }
                else if (action == "remove")
                {
                    var count = int.Parse(arg[1]);

                    if (count > stack.Count)
                    {
                        continue;
                    }

                    RemoveElements(stack, count);
                }
            }
        }

        private static void RemoveElements(Stack<int> stack, int count)
        {
            for (int i = 0; i < count; i++)
            {
               stack.Pop();
            }
        }

        private static void AddElements(Stack<int> stack, string[] arg)
        {
            var intArr = arg[1]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < intArr.Length; i++)
            {
                var element = intArr[i];

                stack.Push(element);
            }
        }
    }
}
