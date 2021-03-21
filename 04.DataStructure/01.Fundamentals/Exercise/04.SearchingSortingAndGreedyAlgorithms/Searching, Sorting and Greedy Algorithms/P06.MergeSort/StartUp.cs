namespace P06.MergeSort
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var numbers = Console
               .ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            MergeSort(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void MergeSort(int[] source)
        {
            var copy = new int[source.Length];
            MergeSortHelper(source, copy, 0, source.Length - 1);
        }

        private static void MergeSortHelper(int[] source, int[] copy, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex) return;

            var middleIndex = (leftIndex + rightIndex) / 2;
            MergeSortHelper(source, copy, leftIndex, middleIndex);
            MergeSortHelper(source, copy, middleIndex + 1, rightIndex);

            MergeArrays(source, copy, leftIndex, middleIndex, rightIndex);
        }

        private static void MergeArrays(int[] source,
            int[] copy,
            int startIndex,
            int middleIndex,
            int endIndex)
        {
            Array.Copy(source, copy, endIndex + 1);

            var sourceIndex = startIndex;
            var leftIndex = startIndex;
            var rightIndex = middleIndex + 1;

            while (leftIndex <= middleIndex
                && rightIndex <= endIndex)
                if (copy[leftIndex] < copy[rightIndex])
                    source[sourceIndex++] = copy[leftIndex++];
                else source[sourceIndex++] = copy[rightIndex++];

            while (leftIndex <= middleIndex)
                source[sourceIndex++] = copy[leftIndex++];

            while (rightIndex <= endIndex)
                source[sourceIndex++] = copy[rightIndex++];
        }
    }
}
