using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class StartUp
    {
        static void Main()
        {
            var minFunc = new Func<int[], int>(x =>
            {
                var min = int.MaxValue;

                for (int i = 0; i < x.Length; i++)
                {
                    if (x[i] < min)
                    {
                        min = x[i];
                    }
                }

                return min;
            });

            var input = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(minFunc(input));
        }
    }
}
