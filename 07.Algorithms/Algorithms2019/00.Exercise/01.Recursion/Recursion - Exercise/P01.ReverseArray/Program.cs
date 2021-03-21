
namespace P01.ReverseArray
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var arr = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            ReverseArr(arr, 0);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void ReverseArr(int[] arr, int startIndex)
        {
            if (startIndex >= arr.Length / 2) return;

            Swap(arr, startIndex, arr.Length - startIndex - 1);
            ReverseArr(arr, startIndex + 1);
        }

        private static void Swap(int[] arr, int firstIndex, int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }
    }
}
