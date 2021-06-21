namespace P12.TriFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var names = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Func<string, int, bool> pred = (str, num) =>
            {
                return str.Sum(c => c) >= num;
            };

            Func<string[], Func<string, int, bool>, string> triFunc = (arr, pred) =>
            {
                foreach (var word in arr)
                {
                    if (pred(word, number))
                    {
                        return word;
                    }
                }

                return string.Empty;
            };

            var name = triFunc(names, pred);

            Console.WriteLine(name);
        }
    }
}
