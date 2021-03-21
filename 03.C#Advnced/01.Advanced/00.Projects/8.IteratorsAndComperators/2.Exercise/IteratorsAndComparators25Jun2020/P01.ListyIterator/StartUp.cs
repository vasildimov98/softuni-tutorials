namespace P01.ListyIterator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static ListyIterator<string> listyIterator;
        public static void Main()
        {
            Run();
        }

        private static void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var args = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = args[0];

                ProceedCommands(args, action);
            }
        }

        private static void ProceedCommands(string[] args, string action)
        {
            if (action == "Create")
            {
                var arr = args.Skip(1).ToArray();

                listyIterator = new ListyIterator<string>(arr);
            }
            else if (action == "Move")
            {
                Console.WriteLine(listyIterator.Move());
            }
            else if (action == "Print")
            {
                listyIterator.Print();
            }
            else if (action == "PrintAll")
            {
                listyIterator.PrintAll();
            }
            else if (action == "HasNext")
            {
                Console.WriteLine(listyIterator.HasNext());
            }
        }
    }
}
