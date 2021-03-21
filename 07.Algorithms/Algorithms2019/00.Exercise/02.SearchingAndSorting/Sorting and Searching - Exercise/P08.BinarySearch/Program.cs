namespace P08.BinarySearch
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

            var numberToSearch = int.Parse(Console.ReadLine());

            var numberIndexInCollection = FindNumberIndex(arr, numberToSearch, 0, arr.Length - 1);

            Console.WriteLine(numberIndexInCollection);
        }

        private static int FindNumberIndex(int[] arr,
            int numberToSearch,
            int startIndex,
            int endIndex)
        {
            if (endIndex < startIndex) return -1;

            var middleIndex = (startIndex + endIndex) / 2;

            if (numberToSearch > arr[middleIndex])
                return FindNumberIndex(arr, numberToSearch, middleIndex + 1, endIndex);
            else if (numberToSearch < arr[middleIndex])
                return FindNumberIndex(arr, numberToSearch, startIndex, middleIndex - 1);
            else return middleIndex;
        }
    }
}
