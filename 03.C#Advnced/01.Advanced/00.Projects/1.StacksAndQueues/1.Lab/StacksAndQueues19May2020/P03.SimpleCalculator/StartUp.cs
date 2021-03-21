namespace P03.SimpleCalculator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console
                 .ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            var stack = new Stack<string>(input.Reverse());

            MakeAllOperation(stack);

            Console.WriteLine(stack.Peek());
        }

        private static void MakeAllOperation(Stack<string> stack)
        {
            while (stack.Count > 1)
            {
                var firstEl = int.Parse(stack.Pop());
                var operation = stack.Pop();
                var secondEl = int.Parse(stack.Pop());

                switch (operation)
                {
                    case "+":
                        stack.Push((firstEl + secondEl).ToString());
                        break;
                    case "-":
                        stack.Push((firstEl - secondEl).ToString());
                        break;
                }
            }
        }
    }
}
