namespace P04.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var arithmeticExpression = Console.ReadLine();

            var stack = new Stack<int>();

            for (int i = 0; i < arithmeticExpression.Length; i++)
            {
                var elm = arithmeticExpression[i];

                if (elm == '(')
                {
                    stack.Push(i);
                }

                if (elm == ')')
                {
                    var start = stack.Pop();
                    var end = i;

                    for (int j = start; j < end + 1; j++)
                    {
                        Console.Write(arithmeticExpression[j]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
