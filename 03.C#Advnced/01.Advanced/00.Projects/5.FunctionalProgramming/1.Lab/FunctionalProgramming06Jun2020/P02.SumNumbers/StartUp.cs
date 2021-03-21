namespace P02.SumNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            Func<string, int> parser = str => int.Parse(str);

            var result = Console
                .ReadLine()
                .Split(", ")
                .Select(parser)
                .ToList();

            Console.WriteLine(result.Count);
            Console.WriteLine(result.Sum());
        }
    }
}
