namespace P03.BubbleSort
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

            BubbleSort(collection);

            Console.WriteLine(string.Join(" ", collection));
        }

        private static void BubbleSort(int[] collection)
        {
            for (int index = 0; index < collection.Length; index++)
            {
                var max = 0;
                for (int curr = 1; curr < collection.Length - index; curr++)
                    if (collection[curr] < collection[max])
                    {
                        Swap(max, curr, collection);
                        max++;
                    }
                    else max++;
            }
        }

        private static void Swap(int index, int curr, int[] collection)
        {
            var temp = collection[index];
            collection[index] = collection[curr];
            collection[curr] = temp;
        }
    }
}
