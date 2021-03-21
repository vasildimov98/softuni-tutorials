namespace P07.LinearSearch
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

            var numberIndexInCollection = FindNumberIndex(arr, numberToSearch);

            Console.WriteLine(numberIndexInCollection);
        }

        private static int FindNumberIndex(int[] arr, int numberToSearch)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == numberToSearch) return i;
            }

            return -1;
        }
    }
}
