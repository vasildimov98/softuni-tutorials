namespace _01._Reverse_Array
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var arr = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            ReverseArray(arr, 0);
            Console.WriteLine(String.Join(" ", arr));
        }

        private static void ReverseArray(int[] arr, int left)
        {
            if (left >= arr.Length / 2) return;

            var right = arr.Length - 1 - left;
            Swap(arr, left, right);
            ReverseArray(arr, left + 1);
        }

        private static void Swap(int[] arr, int left, int right)
        {
            var temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
        }
    }
}
