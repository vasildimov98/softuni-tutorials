using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class StartUp
    {
        static void Main()
        {
            Func<string, int> func = x => int.Parse(x);

            var list = Console
                .ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(func)
                .ToList();

            Console.WriteLine(list.Count);
            Console.WriteLine(list.Sum());
        }
    }
}
