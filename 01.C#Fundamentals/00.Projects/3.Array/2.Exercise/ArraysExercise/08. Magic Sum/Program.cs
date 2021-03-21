using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main()
        {
            int[] arr = Console
                .ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            int magicNumber = int.Parse(Console.ReadLine());
          
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {         
                    if (arr[i] + arr[j] == magicNumber)
                    {
                        Console.WriteLine(arr[i] + " " + arr[j]);
                    }
                }
            }
        }
    }
}
