using System;
using System.Linq;

namespace P09.BinarySearch
{
    class StartUp
    {
        static void Main()
        {
            var sortedElements = Console
                 .ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            var element = int.Parse(Console.ReadLine());

            var index = FindIndex(sortedElements, element);

            Console.WriteLine(index);
        }

        private static int FindIndex(int[] arr, int element)
        {
            var leftIndex = 0;
            var rightIndex = arr.Length - 1;

            while (leftIndex <= rightIndex)
            {
                var midPoint = leftIndex + (rightIndex - leftIndex) / 2;

                if (element == arr[midPoint])
                {
                    return midPoint;
                }
                else if (element > arr[midPoint])
                {
                    leftIndex = midPoint + 1;
                }
                else
                {
                   rightIndex = midPoint - 1;
                }
            }

            return -1;
        }
    }
}
