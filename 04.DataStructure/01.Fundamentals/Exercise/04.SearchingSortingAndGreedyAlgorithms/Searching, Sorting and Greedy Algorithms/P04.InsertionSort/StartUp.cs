namespace P04.InsertionSort
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

            InserionSort(unsortedCollection);

            Console.WriteLine(string.Join(" ", unsortedCollection));
        }

        private static void InserionSort(int[] unsortedCollection)
        {
            for (int index = 1; index < unsortedCollection.Length; index++)
            {
                var leftIndex = index;
                while (leftIndex > 0
                    && unsortedCollection[leftIndex] < unsortedCollection[leftIndex - 1])
                {
                    Swap(unsortedCollection, leftIndex, leftIndex - 1);
                    leftIndex--;
                }
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
