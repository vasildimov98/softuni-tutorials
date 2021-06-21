using System;
using System.Linq;

namespace P05.SelectionSortCode
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

            SelectionSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        static void SelectionSort(int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                var currNum = arr[index];
                var min = index;
                for (int curr = index + 1; curr < arr.Length; curr++)
                {
                    if (currNum >= arr[curr])
                    {
                        min = curr;
                    }
                }

                Swap(arr, index, min);
            }
        }

        private static void Swap(int[] arr, int currNum, int min)
        {
            var temp = arr[currNum];
            arr[currNum] = arr[min];
            arr[min] = temp;
        }
    }
}
