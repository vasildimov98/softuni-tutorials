using System;
using System.Linq;

namespace P01.RecursiveArraySum
{
    class StartUp
    {
        static void Main()
        {
            var arr = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var arrSum = ArraySum(arr);

            Console.WriteLine(arrSum);
        }

        static int ArraySum(int[] arr, int index = 0)
        {
            if (index == arr.Length - 1)
            {
                return arr[index];
            }

            var currentSum = arr[index] + ArraySum(arr, index + 1);

            return currentSum;
        }
    }
}
