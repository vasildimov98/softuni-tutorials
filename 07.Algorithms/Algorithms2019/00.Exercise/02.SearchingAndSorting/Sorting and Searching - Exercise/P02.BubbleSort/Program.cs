namespace P02.BubbleSort
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

            BubbleSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void BubbleSort(int[] arr)
        {
            var isSorted = false;
            var index = 0;
            while (!isSorted)
            {
                isSorted = true;
                var firstIndex = 0;
                for (int nextIndex = firstIndex + 1; nextIndex < arr.Length - index; nextIndex++)
                    if (arr[firstIndex] > arr[nextIndex])
                    {
                        isSorted = false;
                        Swap(arr, firstIndex++, nextIndex);
                    }
                    else firstIndex++;

                index++;
            }
        }

        private static void Swap(int[] arr, int firstIndex, int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }
    }
}
