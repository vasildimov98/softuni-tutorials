namespace P01.ActionPrint
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Action<string> printer = Console.WriteLine;

            Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printer);
        }
    }
}
