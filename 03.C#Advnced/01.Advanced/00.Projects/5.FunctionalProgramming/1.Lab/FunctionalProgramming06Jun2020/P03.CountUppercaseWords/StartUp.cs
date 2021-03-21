namespace P03.CountUppercaseWords
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Func<string, bool> predicate = str => char.IsUpper(str[0]);

            Action<string> print = str => Console.WriteLine(str);

            Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(predicate)
                .ToList()
                .ForEach(print);
        }
    }
}
