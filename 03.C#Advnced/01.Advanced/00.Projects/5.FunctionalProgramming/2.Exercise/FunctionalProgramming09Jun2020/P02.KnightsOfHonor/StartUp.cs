namespace P02.KnightsOfHonor
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            Action<string> appendPrint = n =>
            {
                Console.WriteLine($"Sir {n}");
            };

            Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(appendPrint);
        }
    }
}
