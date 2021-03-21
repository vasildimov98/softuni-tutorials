using System;

namespace _02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            arr[0] = 1;

            for (int i = 0; i < n; i++)
            {
                int leftNum = 0;
                int rightNum = 0;
                int[] arr1 = new int[i + 1];
                arr1[0] = 1;
                int[] arr2 = new int[i + 1];
                for (int j = 1; j < arr1.Length; j++)
                {
                    if (!(j - 1 < 0))
                    {
                        leftNum = arr[j - 1];
                    }

                    if (!(j + 1 > arr2.Length))
                    {
                        rightNum = arr[j];
                    }

                    arr1[j] = leftNum + rightNum;
                }

                Console.WriteLine(string.Join(" ", arr1));

                for (int index = 1; index < arr1.Length; index++)
                {
                    arr[index] = arr1[index];
                }
            }
        }
    }
}

