namespace P01.BinarySearch
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var collection = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var elementToFind = int.Parse(Console.ReadLine()); 
            var startIndex = 0;
            var endIndex = collection.Length - 1;

            var indexOfElement = BinarySearch(collection, elementToFind, startIndex, endIndex);
            Console.WriteLine(indexOfElement);
        }

        private static int BinarySearch(int[] collection, int element, int startIndex, int endIndex)
        {
            if (endIndex < startIndex) return -1;

            var midIndex = (startIndex + endIndex) / 2;

            if (element > collection[midIndex])
                return BinarySearch(collection, element, midIndex + 1, endIndex);
            else if (element < collection[midIndex])
                return BinarySearch(collection, element, startIndex, midIndex - 1);
            else return midIndex;
        }
    }
}
