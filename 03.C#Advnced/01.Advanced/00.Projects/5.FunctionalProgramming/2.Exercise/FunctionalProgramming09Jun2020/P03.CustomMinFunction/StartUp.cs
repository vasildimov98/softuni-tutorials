namespace P03.CustomMinFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Func<int[], int> min = arr =>
            {

                if (arr.Length == 0)
                {
                    return 0;
                }

                var min = int.MaxValue;

                foreach (var num in arr)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }

                return min;
            };

            var arr = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var minNumber = min(arr);

            Console.WriteLine(minNumber);
        }
    }
}
