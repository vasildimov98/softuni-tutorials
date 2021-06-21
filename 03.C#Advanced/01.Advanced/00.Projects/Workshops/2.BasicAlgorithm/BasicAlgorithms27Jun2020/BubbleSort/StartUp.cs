namespace BubbleSort
{
    using System;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            var arr = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            BubbleSort<int>.Sort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
