namespace P04.InsertionSort
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

            InsertionSort(collection);

            Console.WriteLine(string.Join(" ", collection));
        }

        private static void InsertionSort(int[] collection)
        {
            for (int curr = 1; curr < collection.Length; curr++)
            {
                var max = curr;
                for (int prev = curr - 1; prev >= 0; prev--)
                {
                    if (collection[curr] < collection[prev]) max = prev;
                    else break;
                }

                if (max != curr)
                    Insert(collection, max, curr);
            }
        }

        private static void Insert(int[] collection, int start, int end)
        {
            var temp = collection[end];
            //var count = 0;
            //for (int i = start; i < end; i++)
            //{
            //    collection[end - count] = collection[end - count++ - 1];
            //}

            for (int i = end; i > start; i--)
            {
                collection[i] = collection[i - 1];
            }

            collection[start] = temp;
        }
    }
}
