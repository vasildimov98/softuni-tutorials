namespace P02.ParallerMergeSort
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main()
        {
            var repository = new UnsortedRepository();

            var unsortedList = repository.UnsortedList;

            var sw = Stopwatch.StartNew();

            //var sorted = MergeSort(unsortedList);

            var sorted = await MergeSort(unsortedList);

            Console.WriteLine(sw.Elapsed.Milliseconds);

            Console.WriteLine(string.Join(",", sorted));
        }

        private static async Task<List<int>> MergeSort(List<int> list)
        {
            if (list.Count <= 1) return list;

            var leftList = new List<int>();
            var rightList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0) leftList.Add(list[i]);
                else rightList.Add(list[i]);
            }

            leftList = await Task.Run(() => MergeSort(leftList));
            rightList = await Task.Run(() => MergeSort(rightList));

            return Merge(leftList, rightList);
        }

        private static List<int> Merge(List<int> leftList, List<int> rightList)
        {
            var output = new List<int>();

            while (leftList.Any() || rightList.Any())
            {
                if (!rightList.Any())
                {
                    output.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else if (!leftList.Any())
                {
                    output.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
                else if (leftList[0] <= rightList[0])
                {
                    output.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else
                {
                    output.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }

            return output;
        }
    }
}
