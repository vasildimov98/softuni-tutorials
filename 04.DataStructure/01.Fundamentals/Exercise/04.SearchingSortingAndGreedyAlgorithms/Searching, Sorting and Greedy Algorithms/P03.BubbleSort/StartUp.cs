namespace P03.BubbleSort
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

            BubbleSort(unsortedCollection);

            Console.WriteLine(string.Join(" ", unsortedCollection));
        }

        private static void BubbleSort(int[] unsortedCollection)
        {
            var isSorted = false;
            var index = 0;
            while (!isSorted)
            {
                isSorted = true;
                for (int nextIndex = 1; nextIndex < unsortedCollection.Length - index; nextIndex++)
                    if (unsortedCollection[nextIndex - 1] > unsortedCollection[nextIndex])
                    {
                        isSorted = false;
                        Swap(unsortedCollection, nextIndex - 1, nextIndex);
                    }
                index++;
            }
        }

        private static void Swap(int[] unsortedCollection, int firstIndex, int secondIndex)
        {
            var temp = unsortedCollection[firstIndex];
            unsortedCollection[firstIndex] = unsortedCollection[secondIndex];
            unsortedCollection[secondIndex] = temp;
        }
    }
}
