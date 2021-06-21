using System;
using System.Linq;

namespace _01._Action_Print
{
    class StartUp
    {
        static void Main()
        {
            //Action<string> print = new Action<string>(x =>
            //{
            //    Console.WriteLine(x);
            //});

            Console
                .ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(new Action<string>(x =>
                {
                    Console.WriteLine(x);
                }));
        }
    }
}
