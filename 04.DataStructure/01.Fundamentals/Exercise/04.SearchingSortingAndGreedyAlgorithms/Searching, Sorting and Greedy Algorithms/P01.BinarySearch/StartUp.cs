namespace P01.BinarySearch
{
    using System;
    using System.Linq;
    class StartUp
    {
        static void Main()
        {
            var collection = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());
            var index = FindIndex(collection, target);
            Console.WriteLine(index);
       }

        private static int FindIndex(int[] collection, int target)
        {
            var leftIndex = 0;
            var rightIndex = collection.Length - 1;

            while (leftIndex <= rightIndex)
            {
                var midIndex = (leftIndex + rightIndex) / 2;
                var currMidElement = collection[midIndex];
                if (currMidElement == target) return midIndex;

                if (target > collection[midIndex]) leftIndex = midIndex + 1;
                else rightIndex = midIndex - 1;
            }

            return -1;
        }
    }
}
