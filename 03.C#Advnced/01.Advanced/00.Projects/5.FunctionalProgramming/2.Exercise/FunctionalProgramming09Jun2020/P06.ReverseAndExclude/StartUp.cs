namespace P06.ReverseAndExclude
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Func<int[], int, int[]> remover = (c, d) =>
            {
                var newArr = c
                   .Where(n => n % d != 0)
                   .ToArray();

                return newArr;
            };

            Func<int[], int[]> reverser = c =>
            {
                for (int i = 0; i < c.Length / 2; i++)
                {
                    var temp = c[i];
                    c[i] = c[c.Length - 1 - i];
                    c[c.Length - 1 - i] = temp;
                }

                return c;
            };

            var collection = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var num = int.Parse(Console.ReadLine());

            collection = remover(collection, num);
            collection = reverser(collection);

            Console.WriteLine(string.Join(" ", collection));
        }
    }
}
