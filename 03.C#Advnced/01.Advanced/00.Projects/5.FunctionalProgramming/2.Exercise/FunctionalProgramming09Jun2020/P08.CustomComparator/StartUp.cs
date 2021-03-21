namespace P08.CustomComparator
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

            Func<int, int, int> comparer = (f, s) =>
            {
                if (f % 2 == 0 && s % 2 != 0)
                {
                    return -1;
                }
                else if (f % 2 != 0 && s % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    if (f > s)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            };

            var customComparator = new Comparison<int>(comparer);

            Array.Sort(arr, customComparator);

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
