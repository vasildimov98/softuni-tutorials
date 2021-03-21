namespace P02.SelectionSort
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

            SelectionSort(unsortedCollection);

            Console.WriteLine(string.Join(" ", unsortedCollection));
        }

        private static void SelectionSort(int[] unsortedCollection)
        {
            for (int index = 0; index < unsortedCollection.Length; index++)
            {
                var minIndex = index;
                for (int curr = index + 1; curr < unsortedCollection.Length; curr++)
                {
                    if (unsortedCollection[curr] < unsortedCollection[minIndex])
                        minIndex = curr;

                }
                Swap(unsortedCollection, index, minIndex);
            }
        }

        private static void Swap(int[] collection, int firstIndex, int secondIndex)
        {
            var temp = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temp;
        }
    }
}
