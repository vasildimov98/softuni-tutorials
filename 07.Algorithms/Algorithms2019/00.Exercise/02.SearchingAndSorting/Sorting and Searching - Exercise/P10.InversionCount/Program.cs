namespace P10.InversionCount
{
    using System;
    using System.Linq;

    class Program
    {
        private static int[] auxArr;
        static void Main()
        {
            var arrInput = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var count = StartMergeSort(arrInput);

            Console.WriteLine(count);
        }

        private static int StartMergeSort(int[] source)
        {
            var startIndex = 0;
            var endIndex = source.Length - 1;

            auxArr = new int[source.Length];
            return Split(source, startIndex, endIndex);
        }

        private static int Split(int[] source,
            int startIndex,
            int endIndex)
        {
            var invCount = 0;
            if (startIndex >= endIndex) return invCount;

            var middleIndex = (startIndex + endIndex) / 2;

            invCount = Split(source, startIndex, middleIndex);
            invCount += Split(source, middleIndex + 1, endIndex);

            invCount += MergeArr(source, startIndex, middleIndex + 1, endIndex);

            return invCount;
        }

        private static int MergeArr(int[] source,
            int startIndex,
            int middleIndex,
            int endIndex)
        {
            var invCount = 0;
            if (IsLess(source[middleIndex - 1], source[middleIndex])) return invCount;

            for (int index = startIndex; index <= endIndex; index++)
                auxArr[index] = source[index];

            var firstArrIndex = startIndex;
            var secondArrIndex = middleIndex;
            for (int sourceIndex = startIndex; sourceIndex <= endIndex; sourceIndex++)
                if (secondArrIndex > endIndex)
                    source[sourceIndex] = auxArr[firstArrIndex++];
                else if (firstArrIndex > middleIndex - 1)
                    source[sourceIndex] = auxArr[secondArrIndex++];
                else if (IsLess(auxArr[firstArrIndex], auxArr[secondArrIndex]))
                    source[sourceIndex] = auxArr[firstArrIndex++];
                else
                {
                    source[sourceIndex] = auxArr[secondArrIndex++];
                    invCount = invCount + (middleIndex - firstArrIndex);
                }

            return invCount;
        }

        private static bool IsLess(int firstEl, int secondEl)
            => firstEl.CompareTo(secondEl) <= 0;

        //private static int GetInversionsCountSimple(int[] arr)
        //{
        //    var count = 0;

        //    for (int i = 0; i < arr.Length; i++)
        //        for (int j = i + 1; j < arr.Length; j++)
        //            if (arr[i] > arr[j])
        //                count++;

        //    return count;
        //}
    }
}
