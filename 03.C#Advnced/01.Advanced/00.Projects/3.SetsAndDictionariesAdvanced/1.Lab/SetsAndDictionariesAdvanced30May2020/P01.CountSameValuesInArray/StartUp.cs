namespace P01.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var counter = new Dictionary<string, int>();

            var numbers = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (var number in numbers)
            {
                if (!counter.ContainsKey(number))
                {
                    counter[number] = 0;
                }

                counter[number]++;
            }

            foreach (var (number, count) in counter)
            {
                Console.WriteLine($"{number} - {count} times");
            }
        }
    }
}
