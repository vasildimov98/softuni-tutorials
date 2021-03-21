namespace P03.ShellSort
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

            ShellSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void ShellSort(int[] arr)
        {
            var size = arr.Length;
            var gap = size / 2;

            int currIndex;
            int temp;
            int prevIndex;

            while (gap > 0)
            {
                currIndex = gap;

                while (currIndex < size)
                {
                    temp = arr[currIndex];

                    for (prevIndex = currIndex; prevIndex >= gap
                        && arr[prevIndex - gap] > temp; prevIndex -= gap)
                        arr[prevIndex] = arr[prevIndex - gap];

                    arr[prevIndex] = temp;

                    currIndex++;
                }

                gap /= 2;
            }
        }
    }
}
