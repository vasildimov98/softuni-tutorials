namespace P06.MergeSort
{
    using System;
    using System.Linq;

    class Program
    {
        private static int[] auxArr;
        static void Main()
        {
            var collection = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            MergeSort(collection);
            Console.WriteLine(string.Join(" ", collection));
        }

        private static void MergeSort(int[] collection)
        {
            auxArr = new int[collection.Length];
            Sort(collection, 0, collection.Length - 1);
        }

        private static void Sort(int[] collection, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) return;

            var middleIndex = (startIndex + endIndex) / 2;

            Sort(collection, startIndex, middleIndex);
            Sort(collection, middleIndex + 1, endIndex);

            MergeElements(collection, startIndex, middleIndex, endIndex);
        }

        private static void MergeElements(int[] collection, int startIndex, int middleIndex, int endIndex)
        {
            if (IsLess(collection[middleIndex], collection[middleIndex + 1]))
                return;

            for (int index = startIndex; index < endIndex + 1; index++)
                auxArr[index] = collection[index];

            var firstArrIndex = startIndex;
            var secondArrIndex = middleIndex + 1;

            for (int sourceIndex = startIndex; sourceIndex <= endIndex; sourceIndex++)
                if (secondArrIndex > endIndex)
                    collection[sourceIndex] = auxArr[firstArrIndex++];
                else if (firstArrIndex > middleIndex)
                    collection[sourceIndex] = auxArr[secondArrIndex++];
                else if (IsLess(auxArr[firstArrIndex], auxArr[secondArrIndex]))
                    collection[sourceIndex] = auxArr[firstArrIndex++];
                else collection[sourceIndex] = auxArr[secondArrIndex++];

            //var sourceIndex = startIndex;

            //while (firstArrIndex <= middleIndex
            //    && secondArrIndex <= endIndex)
            //    if (auxArr[firstArrIndex] < auxArr[secondArrIndex])
            //        collection[sourceIndex++] = auxArr[firstArrIndex++];
            //    else collection[sourceIndex++] = auxArr[secondArrIndex++];


            //while (firstArrIndex <= middleIndex)
            //    collection[sourceIndex++] = auxArr[firstArrIndex++];

            //while (secondArrIndex <= endIndex)
            //    collection[sourceIndex++] = auxArr[secondArrIndex++];
        }

        private static bool IsLess(int first, int second)
        {
            return first.CompareTo(second) < 0;
        }
    }
}
