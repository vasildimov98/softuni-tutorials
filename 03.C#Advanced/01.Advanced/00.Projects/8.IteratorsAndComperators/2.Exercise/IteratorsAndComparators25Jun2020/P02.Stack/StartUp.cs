namespace P02.Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static MyStack<int> myStack = new MyStack<int>();
        public static void Main()
        {
            Run();
            Print();
        }

        private static void Print()
        {
            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }

            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }
        }

        private static void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var args = command
                    .Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = args[0];

                try
                {
                    ProceedCommand(args, action);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void ProceedCommand(string[] args, string action)
        {
            if (action == "Push")
            {
                var numbers = args[1]
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                foreach (var number in numbers)
                {
                    myStack.Push(number);
                }
            }
            else
            {
                myStack.Pop();
            }
        }
    }
}
