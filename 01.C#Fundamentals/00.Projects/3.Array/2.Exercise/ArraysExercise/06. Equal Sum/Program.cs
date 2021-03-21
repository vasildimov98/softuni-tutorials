using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

           

            for (int i = 0; i < arr.Length; i++)
            {

                if (arr.Length == 1)
                {
                    Console.WriteLine(i);
                    return;
                }

                int currNum = arr[i];
              
                int leftSum = 0;
                for (int j = 0; j < i; j++)
                {
                    leftSum += arr[j];
                }

                int rightSum = 0;
                for (int k = i; k < arr.Length - 1; k++)
                {
                    rightSum += arr[k + 1];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}
