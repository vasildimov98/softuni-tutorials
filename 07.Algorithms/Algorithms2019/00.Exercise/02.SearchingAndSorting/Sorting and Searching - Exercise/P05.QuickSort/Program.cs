namespace P05.QuickSort
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

            var startIndex = 0;
            var endIndex = arr.Length - 1;
            ShuffleArray(arr);

            QuickSort(arr, startIndex, endIndex);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void ShuffleArray(int[] arr)
        {
            var rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                var randomIndex = i + rnd.Next(0, arr
                    .Length - i);

                Swap(arr, i, randomIndex);
            }
        }

        private static void QuickSort(int[] arr,
            int startIndex,
            int endIndex)
        {
            if (startIndex >= endIndex) return;

            var pivotIndex = GetPivotIndex(arr, startIndex, endIndex);

            var isLeftSmaller = pivotIndex - 1 - startIndex < endIndex - (pivotIndex + 1);

            if (isLeftSmaller)
            {
                QuickSort(arr, startIndex, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, endIndex);
            }
            else
            {
                QuickSort(arr, pivotIndex + 1, endIndex);
                QuickSort(arr, startIndex, pivotIndex - 1);
            }
        }

        private static int GetPivotIndex(int[] arr,
            int startIndex,
            int endIndex)
        {
            var pivotIndex = startIndex;
            var leftIndex = pivotIndex + 1;
            var rightIndex = endIndex;

            while (leftIndex <= rightIndex)
            {
                if (IsLess(arr[pivotIndex], arr[leftIndex])
                    && IsLess(arr[rightIndex], arr[pivotIndex]))
                    Swap(arr, leftIndex, rightIndex);

                if (IsLess(arr[leftIndex], arr[pivotIndex]))
                    leftIndex++;

                if (IsLess(arr[pivotIndex], arr[rightIndex]))
                    rightIndex--;
            }

            Swap(arr, pivotIndex, rightIndex);

            return rightIndex;
        }

        private static void Swap(int[] arr, int leftIndex, int rightIndex)
        {
            var temp = arr[leftIndex];
            arr[leftIndex] = arr[rightIndex];
            arr[rightIndex] = temp;
        }

        private static bool IsLess(int firstNumber, int secondNumber)
            => firstNumber.CompareTo(secondNumber) <= 0;
    }
}
