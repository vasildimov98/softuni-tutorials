namespace P12_IterativePermutationsWithRepetition
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
                .ToArray();

            Array.Sort(arr);

            IterativePermutationsWithRepetition(arr);
        }

        private static void IterativePermutationsWithRepetition(string[] arr)
        {
            var currIndex = 0;

            while (currIndex < arr.Length - 1)
            {
                if (arr[currIndex] == arr[currIndex + 1])
                {
                    currIndex++;
                    continue;
                }
                
                var swaptIndex = currIndex;
                while (swaptIndex < arr.Length - 1)
                {
                    Console.WriteLine(string.Join(" ", arr));
                    Swap(arr, swaptIndex, swaptIndex++ + 1);
                }

                Console.WriteLine(string.Join(" ", arr));
                currIndex++;
            }
        }

        private static void Swap(string[] arr, int swaptIndex, int nextIndex)
        {
            var temp = arr[swaptIndex];
            arr[swaptIndex] = arr[nextIndex];
            arr[nextIndex] = temp;
        }
    }
}
