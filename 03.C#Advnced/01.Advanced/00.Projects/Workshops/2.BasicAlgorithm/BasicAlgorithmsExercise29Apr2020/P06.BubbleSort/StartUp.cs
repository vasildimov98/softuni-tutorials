using System;
using System.Linq;

namespace P06.BubbleSort
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

            BubbleSort(arr);

            Console.WriteLine(string.Join(" ", arr));

            //int[] numbers = { 5, 4, 3, 2, 1, -2 };
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    for (int j = i + 1; j < numbers.Length - 1; j++)
            //    {
            //        if (numbers[i] > numbers[j])
            //        {
            //            int tempNumber = numbers[i];
            //            numbers[i] = numbers[j];
            //            numbers[j] = tempNumber;
            //        }
            //    }
            //}
            //Console.WriteLine(string.Join(" ", numbers));

        }

        static void BubbleSort(int[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                for (int curr = index + 1; curr < arr.Length; curr++)
                {
                    if (arr[index] > arr[curr])
                    {
                        var temp = arr[index];
                        arr[index] = arr[curr];
                        arr[curr] = temp;
                    }
                }
            }
        }
    }
}
