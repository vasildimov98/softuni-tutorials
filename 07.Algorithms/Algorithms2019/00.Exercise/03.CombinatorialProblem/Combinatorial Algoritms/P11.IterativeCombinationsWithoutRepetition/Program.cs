namespace P11.IterativeCombinationsWithoutRepetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            IterativeCombinationsWithoutRepetition();
        }

        private static void IterativeCombinationsWithoutRepetition()
        {
            var set = Console
                .ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            var slots = int.Parse(Console.ReadLine());

            var firstElement = set[0];
            var lastElement = set[^1];

            var vector = new char[slots];
            var stack = new Stack<char>();

            stack.Push(firstElement);
            while (stack.Count > 0)
            {
                var index = stack.Count - 1;
                var value = stack.Pop();

                while (value <= lastElement)
                {
                    vector[index++] = value++;
                    stack.Push(value);

                    if (index == slots)
                    {
                        Console.WriteLine(string.Join(" ", vector));
                        break;
                    }
                }
            }
        }
    }
}
