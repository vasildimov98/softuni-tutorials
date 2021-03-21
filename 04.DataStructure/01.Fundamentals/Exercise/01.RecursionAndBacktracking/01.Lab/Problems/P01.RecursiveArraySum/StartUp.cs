namespace P01.RecursiveArraySum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console
                .ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            var sum = GetSumOfArr(numbers);
            Console.WriteLine(sum);
        }

        private static int GetSumOfArr(int[] arr, int index = 0)
        {
            if (index == arr.Length - 1)
                return arr[index];

            var currNumber = arr[index];
            var sum = currNumber + GetSumOfArr(arr, ++index);

            return sum;
        }
    }
}
