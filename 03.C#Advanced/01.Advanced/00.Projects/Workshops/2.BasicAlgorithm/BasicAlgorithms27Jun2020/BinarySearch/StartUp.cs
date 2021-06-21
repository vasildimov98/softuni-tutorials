namespace BinarySearch
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const int KEY_NOT_FOUND = -1;
        static void Main()
        {
            var arr = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var key = int.Parse(Console.ReadLine());

            var result = BinarySearch(arr, key, 0, arr.Length - 1);

            Console.WriteLine(result);
        }

        private static int BinarySearch(int[] arr, int key, int start, int end)
        {
            while (end >= start)
            {
                int mid = (start + end) / 2;

                if (arr[mid] < key)
                {
                    start = mid + 1;
                }
                else if (arr[mid] > key)
                {
                    end = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return KEY_NOT_FOUND;
        }

    }


}
