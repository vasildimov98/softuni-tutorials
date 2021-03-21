namespace P06.BucketSort
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var arr = Console
               .ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();
            //var arr = new int[10000];

            //var rnd = new Random();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = i + 1 * rnd.Next(0, 10000 - i);
            //}


            //Shuffle(arr, rnd);

            var numberOfBuckets = 10;

            BucketSort(arr, numberOfBuckets);

            Console.WriteLine(string.Join(" ", arr));
        }

        //private static void Shuffle(int[] arr, Random rnd)
        //{
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        var randomIndex = i + rnd.Next(0, arr.Length - i);

        //        Swap(arr, i, randomIndex);
        //    }
        //}

        private static void BucketSort(int[] arr, int numberOfBuckets)
        {
            if (arr.Length <= 1) return;

            var positiveBuckets = new List<int>[numberOfBuckets];
            var negativeBuckets = new List<int>[numberOfBuckets];

            var maxElement = arr.Max();
            var minElement = Math.Abs(arr.Min());

            for (int currIndex = 0; currIndex < arr.Length; currIndex++)
            {
                if (arr[currIndex] >= 0)
                {
                    var bucketIndex = GetCorrectBucket(arr, numberOfBuckets, maxElement, currIndex);
                    AddElementToBucket(arr, positiveBuckets, currIndex, bucketIndex);
                }
                else
                {
                    var bucketIndex = GetCorrectBucket(arr, numberOfBuckets, minElement, currIndex);
                    AddElementToBucket(arr, negativeBuckets, currIndex, bucketIndex);
                }
            }

            MoveElementsFromBucketsToArr(arr, numberOfBuckets, negativeBuckets, positiveBuckets);

            InsertionSort(arr);
        }

        private static void AddElementToBucket(int[] arr,
            List<int>[] positiveBuckets,
            int currIndex,
            int bucketIndex)
        {
            if (positiveBuckets[bucketIndex] == null)
                positiveBuckets[bucketIndex] = new List<int>();

            positiveBuckets[bucketIndex].Add(arr[currIndex]);
        }

        private static void InsertionSort(int[] arr)
        {
            for (int currIndex = 1; currIndex < arr.Length; currIndex++)
            {
                var swapIndex = currIndex;
                for (int prevIndex = currIndex - 1; prevIndex >= 0; prevIndex--)
                    if (arr[prevIndex] > arr[swapIndex])
                        Swap(arr, swapIndex--, prevIndex);
                    else break;
            }
        }

        private static void Swap(int[] arr, int currIndex, int prevIndex)
        {
            var temp = arr[currIndex];
            arr[currIndex] = arr[prevIndex];
            arr[prevIndex] = temp;
        }

        private static void MoveElementsFromBucketsToArr(int[] arr, int numberOfBuckets, List<int>[] firstBuckets, List<int>[] secondBucket)
        {
            var currArrIndex = 0;
            for (int bucketIndex = 0; bucketIndex < numberOfBuckets; bucketIndex++)
            {
                var currBucket = firstBuckets[bucketIndex];
                if (currBucket == null) continue;

                for (int i = 0; i < currBucket.Count; i++)
                    arr[currArrIndex++] = currBucket[i];
            }

            for (int bucketIndex = 0; bucketIndex < numberOfBuckets; bucketIndex++)
            {
                var currBucket = secondBucket[bucketIndex];
                if (currBucket == null) continue;

                for (int i = 0; i < currBucket.Count; i++)
                    arr[currArrIndex++] = currBucket[i];
            }
        }

        private static int GetCorrectBucket(int[] arr, int numberOfBuckets, int maxElement, int currIndex)
        {
            var index = numberOfBuckets * Math.Abs(arr[currIndex]) / maxElement;
            return index != numberOfBuckets ? index : index - 1;
        }
    }
}
