namespace BubbleSort
{
    using System;
    public class BubbleSort<T>
        where T : IComparable
    {
        public static void Sort(T[] arr)
        {
            for (int index = 0; index < arr.Length; index++)
            {
                for (int index2 = index + 1; index2 < arr.Length; index2++)
                {
                    if (IsLess(arr[index2], arr[index]))
                    {
                        var temp = arr[index];
                        arr[index] = arr[index2];
                        arr[index2] = temp;
                    }
                }
            }
        }

        private static bool IsLess(T first, T second)
        {
            return first.CompareTo(second) < 0;
        }
    }
}
