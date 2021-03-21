namespace P02.SelectionSort
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

            SelectionSort(collection);

            Console.WriteLine(string.Join(" ", collection));
        }

        private static void SelectionSort(int[] collection)
        {
            for (int index = 0; index < collection.Length; index++)
            {
                var min = index;
                for (int next = index + 1; next < collection.Length; next++)
                {
                    if (collection[next] < collection[min]) min = next;
                }

                Swap(collection, index, min);
            }
        }

        private static void Swap(int[] collection, int index, int min)
        {
            var temp = collection[index];
            collection[index] = collection[min];
            collection[min] = temp;
        }
    }
}
