namespace P01.InsertionSort
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

            InsertionSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void InsertionSort(int[] arr)
        {
            for (int arrIndex = 1; arrIndex < arr.Length; arrIndex++)
            {
                var maxIndex = arrIndex;
                for (int prevIndex = maxIndex - 1; prevIndex >= 0; prevIndex--)
                {
                    if (arr[prevIndex] > arr[arrIndex])
                        maxIndex = prevIndex;
                    else break;
                }

                if (maxIndex != arrIndex)
                    InsertCurrIndexAtCorrectPlace(arr, arrIndex, maxIndex);
            }
        }

        private static void InsertCurrIndexAtCorrectPlace(int[] arr, int startIndex, int endIndex)
        {
            var temp = arr[startIndex];

            for (int i = startIndex; i > endIndex; i--)
                arr[i] = arr[i - 1];

            arr[endIndex] = temp;
        }
    }
}
