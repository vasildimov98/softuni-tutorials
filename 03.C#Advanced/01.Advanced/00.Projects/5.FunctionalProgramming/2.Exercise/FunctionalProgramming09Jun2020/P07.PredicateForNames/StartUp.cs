namespace P07.PredicateForNames
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var length = int.Parse(Console.ReadLine());

            Func<string, bool> predicate = str => str.Length <= length;

            Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(predicate)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
