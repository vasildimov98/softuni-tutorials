namespace SelectionSort
{
    using System;
    public class SelectionSort<T>
        where T : IComparable
    {
        public static void Sort(T[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                var min = index;
                var currElement = arr[index];

                for (int index2 = index + 1; index2 < arr.Length; index2++)
                {
                    if (IsLess(arr[index2], currElement))
                    {
                        min = index2;
                    }
                }

                Swap(arr, index, min);
            }
        }

        private static void Swap(T[] arr, int index, int min)
        {
            var temp = arr[index];
            arr[index] = arr[min];
            arr[min] = temp;
        }

        private static bool IsLess(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) < 0;
        }
    }
}
