using System;
using System.Linq;

namespace _04._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int k = arr.Length / 4;

            int[] firstKNumbers = new int[k];

            for (int i = 0; i < arr.Length - 3 * k; i++)
            {
                firstKNumbers[i] = arr[i];
            }
            firstKNumbers = firstKNumbers.Reverse().ToArray();

            int[] secondKnumbers = new int[k];
            int count = 0;
            for (int i = 3 * k; i < arr.Length; i++)
            {
                secondKnumbers[count] = arr[i];
                count++;
            }

            secondKnumbers = secondKnumbers.Reverse().ToArray();

            int[] firstRow = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                firstRow[i] = firstKNumbers[i];
            }

            count = 0;
            for (int i = k; i < firstRow.Length; i++)
            {
                firstRow[i] = secondKnumbers[count];
                count++;
            }

            count = 0;

            int[] secondRow = new int[2 * k];

            for (int i = k; i < arr.Length - k; i++)
            {
                secondRow[count] = arr[i];
                count++;
            }

            int sum = 0;
            int[] sumNum = new int[2 * k];

            for (int i = 0; i < sumNum.Length; i++)
            {
                sum = firstRow[i] + secondRow[i];
                sumNum[i] = sum;
            }

            Console.WriteLine(string.Join(" ", sumNum));
        }
    }
}
