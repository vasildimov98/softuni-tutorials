using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace P07.MergeSort
{
    public class Mergesort<T>
        where T : IComparable
    {
        private static T[] helpArray;

        public static void Sort(T[] arr)
        {
            helpArray = new T[arr.Length];
            MergeSort(arr, 0, arr.Length - 1);
        }

        private static void MergeSort(T[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var middle = (start + end) / 2;

            MergeSort(arr, start, middle);
            MergeSort(arr, middle + 1, end);
            Merge(arr, start, middle, end);
        }

        private static void Merge(T[] arr, int start, int middle, int end)
        {
            if (IsLess(arr[middle], arr[middle + 1]))
            {
                return;
            }

            for (int i = start; i <= end; i++)
            {
                helpArray[i] = arr[i];
            }

            var leftStartIndex = start;
            var rightStartIndex = middle + 1;

            for (int k = start; k <= end; k++)
            {
                if (leftStartIndex > middle)
                {
                    arr[k] = helpArray[rightStartIndex++];
                }
                else if (rightStartIndex > end)
                {
                    arr[k] = helpArray[leftStartIndex++];
                }
                else if (IsLess(helpArray[leftStartIndex], helpArray[rightStartIndex]))
                {
                    arr[k] = helpArray[leftStartIndex++];
                }
                else
                {
                    arr[k] = helpArray[rightStartIndex++];
                }
            }
        }

        private static bool IsLess(T firstElement, T secondElement)
        {
            return firstElement.CompareTo(secondElement) < 0;
        }
    }
}
