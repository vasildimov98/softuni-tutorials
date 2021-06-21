using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class StartUp
    {
        static void Main()
        {
            var length = int.Parse(Console.ReadLine());

            Func<string, bool> predicate = x => x.Length <= length;

            Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(predicate)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
