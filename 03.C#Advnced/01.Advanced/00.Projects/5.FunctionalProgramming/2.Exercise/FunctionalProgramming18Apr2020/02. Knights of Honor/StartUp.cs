using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class StartUp
    {
        static void Main()
        {
            Console
                .ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(new Action<string>(x =>
               {
                   Console.WriteLine($"Sir {x}");
               }));
        }
    }
}
