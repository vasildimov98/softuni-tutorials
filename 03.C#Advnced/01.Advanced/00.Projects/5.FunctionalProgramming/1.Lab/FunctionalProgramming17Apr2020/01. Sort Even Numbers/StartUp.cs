using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class StartUp
    {
        static void Main()
        {
            var list = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => int.Parse(x) % 2 == 0)
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join(", ", list));
        }
    }
}
