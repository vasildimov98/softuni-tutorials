namespace P01.SortEvenNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Console
                .WriteLine(string
                .Join(", ",
                Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToArray()));
        }
    }
}
