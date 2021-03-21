namespace P04.MergeSort
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

            MergeSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void MergeSort(int[] arr)
        {
            var aux = new int[arr.Length];
            var startIndex = 0;
            var endIndex = arr.Length - 1;
            SplitArray(arr, aux, startIndex, endIndex);
        }

        private static void SplitArray(int[] arr,
            int[] aux,
            int startIndex,
            int endIndex)
        {
            if (startIndex >= endIndex) return;

            var middleIndex = (startIndex + endIndex) / 2;

            SplitArray(arr, aux, startIndex, middleIndex);
            SplitArray(arr, aux, middleIndex + 1, endIndex);

            MergeArrays(arr, aux, startIndex, middleIndex, endIndex);
        }

        private static void MergeArrays(int[] arr,
            int[] auxArr,
            int startIndex,
            int middleIndex,
            int endIndex)
        {
            var rightArrIndex = middleIndex + 1;

            if (IsLess(arr[middleIndex], arr[rightArrIndex])) return;

            for (int auxIndex = startIndex; auxIndex <= endIndex; auxIndex++) auxArr[auxIndex] = arr[auxIndex];

            var leftArrIndex = startIndex;
            for (int sourceIndex = startIndex; sourceIndex <= endIndex; sourceIndex++)
                if (rightArrIndex > endIndex)
                    arr[sourceIndex] = auxArr[leftArrIndex++];
                else if (leftArrIndex > middleIndex)
                    arr[sourceIndex] = auxArr[rightArrIndex++];
                else if (IsLess(auxArr[leftArrIndex], auxArr[rightArrIndex]))
                    arr[sourceIndex] = auxArr[leftArrIndex++];
                else arr[sourceIndex] = auxArr[rightArrIndex++];

        }

        private static bool IsLess(int firstNumber, int secondNumber)
                => firstNumber.CompareTo(secondNumber) <= 0;
    }
}
