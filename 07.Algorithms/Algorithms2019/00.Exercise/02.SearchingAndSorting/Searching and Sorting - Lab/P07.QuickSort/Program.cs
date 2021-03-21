namespace P07.QuickSort
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var collection = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            QuickSort(collection, 0, collection.Length - 1);
            Console.WriteLine(string.Join(" ", collection));
        }

        private static void QuickSort(int[] collection, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) return;

            int pivotIndex = Partition(collection, startIndex, endIndex);

            var leftSubArrIndex = pivotIndex - 1 - startIndex;
            var rightSubArrIndex = endIndex - (pivotIndex + 1);

            var isLeftSubArrSmaller = leftSubArrIndex < rightSubArrIndex;

            if (isLeftSubArrSmaller)
            {
                QuickSort(collection, startIndex, pivotIndex - 1);
                QuickSort(collection, pivotIndex + 1, endIndex);
            }
            else
            {
                QuickSort(collection, pivotIndex + 1, endIndex);
                QuickSort(collection, startIndex, pivotIndex - 1);
            } 
        }

        private static int Partition(int[] collection, int startIndex, int endIndex)
        {
            var pivotIndex = startIndex;
            var leftIndex = startIndex + 1;
            var rightIndex = endIndex;

            while (leftIndex <= rightIndex)
            {
                var leftIsSmaller = IsLess(collection[leftIndex], collection[pivotIndex]);
                var rightIsBigger = IsLess(collection[pivotIndex], collection[rightIndex]);

                if (!leftIsSmaller && !rightIsBigger)
                    Swap(collection, leftIndex, rightIndex);

                if (leftIsSmaller)
                    leftIndex++;

                if (rightIsBigger)
                    rightIndex--;
            }

            Swap(collection, pivotIndex, rightIndex);
            return rightIndex;
        }

        private static void Swap(int[] collection, int leftIndex, int rightIndex)
        {
            var temp = collection[leftIndex];
            collection[leftIndex] = collection[rightIndex];
            collection[rightIndex] = temp;
        }

        private static bool IsLess(int first, int second)
            => first.CompareTo(second) <= 0;
    }
}
