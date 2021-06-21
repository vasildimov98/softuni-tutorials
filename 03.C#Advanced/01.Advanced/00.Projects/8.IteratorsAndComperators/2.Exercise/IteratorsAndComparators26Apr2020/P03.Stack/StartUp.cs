using System;

namespace P03.Stack
{
    public class StartUp
    {
        public static void Main()
        {
            string command;

            var stack = new MyStack<string>(); 
            while ((command = Console.ReadLine()) != "END")
            {
                var data = command
                    .Split(" ", 2, StringSplitOptions.RemoveEmptyEntries);

                var action = data[0];

                if (action == "Push")
                {
                    var elements = data[1].Split(", ");
                    for (int i =  0; i < elements.Length; i++)
                    {
                        stack.Push(elements[i]);
                    }
                }
                else if (action == "Pop")
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("No elements");
                        continue;
                    }

                    stack.Pop();
                }
            }

            foreach (var elm in stack)
            {
                Console.WriteLine(elm);
            }

            foreach (var elm in stack)
            {
                Console.WriteLine(elm);
            }
        }
    }
}
