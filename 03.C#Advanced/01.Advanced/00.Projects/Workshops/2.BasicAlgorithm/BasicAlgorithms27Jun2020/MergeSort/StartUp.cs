namespace MergeSort
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var arr = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            MergeSort<int>.Sort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }
    }

    public class MergeSort<T>
        where T : IComparable
    {
        private static T[] aux;

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var middle = (start + end) / 2;

            Sort(arr, start, middle);
            Sort(arr, middle + 1, end);
            Merge(arr, start, middle, end);
        }

        private static void Merge(T[] arr, int start, int middle, int end)
        {
            if (IsLess(arr[middle], arr[middle + 1]))
            {
                return;
            }

            for (int index = start; index <= end; index++)
            {
                aux[index] = arr[index];
            }

            var leftStartIndex = start;
            var rightStartIndex = middle + 1;

            for (int index = start; index <= end; index++)
            {
                if (leftStartIndex > middle)
                {
                    arr[index] = aux[rightStartIndex++];
                }
                else if (rightStartIndex > end)
                {
                    arr[index] = aux[leftStartIndex++];
                }
                else if (IsLess(aux[leftStartIndex], aux[rightStartIndex]))
                {
                    arr[index] = aux[leftStartIndex++];
                }
                else
                {
                    arr[index] = aux[rightStartIndex++];
                }
            }
        }

        private static bool IsLess(T first, T second)
        {
            return first.CompareTo(second) < 0;
        }
    }
}
