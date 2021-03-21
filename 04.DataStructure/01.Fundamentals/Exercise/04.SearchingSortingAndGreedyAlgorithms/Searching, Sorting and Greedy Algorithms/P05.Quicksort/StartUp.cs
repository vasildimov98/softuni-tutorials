namespace P05.Quicksort
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var unsortedCollection = Console
               .ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            Quicksort(unsortedCollection, 0, unsortedCollection.Length - 1);

            Console.WriteLine(string.Join(" ", unsortedCollection));
        }

        private static void Quicksort(int[] unsortedCollection, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) return;

            var pivotIndex = startIndex;
            var leftIndex = startIndex + 1;
            var rightIndex = endIndex;

            while (leftIndex <= rightIndex)
            {
                if (unsortedCollection[leftIndex] > unsortedCollection[pivotIndex]
                    && unsortedCollection[rightIndex] < unsortedCollection[pivotIndex])
                    Swap(unsortedCollection, leftIndex, rightIndex);

                if (unsortedCollection[leftIndex] <= unsortedCollection[pivotIndex])
                    leftIndex += 1;

                if (unsortedCollection[rightIndex] >= unsortedCollection[pivotIndex])
                    rightIndex -= 1;
            }

            Swap(unsortedCollection, pivotIndex, rightIndex);

            var isLeftSubArraySmaller = rightIndex - 1 - startIndex < endIndex - (rightIndex + 1);

            if (isLeftSubArraySmaller)
            {
                Quicksort(unsortedCollection, startIndex, rightIndex - 1);
                Quicksort(unsortedCollection, rightIndex + 1, endIndex);
            }
            else
            {
                Quicksort(unsortedCollection, rightIndex + 1, endIndex);
                Quicksort(unsortedCollection, startIndex, rightIndex - 1);
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
