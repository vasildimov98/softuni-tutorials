using System;
using System.Linq;

namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();
            int numberOfRotation = int.Parse(Console.ReadLine());
            numberOfRotation %= arr.Length;
            for (int j = 0; j < numberOfRotation; j++)
            {
                int temp = 0;
                for (int i = 0; i < arr.Length - 1; i++)
                {

                    if (i == 0)
                    {
                        temp = arr[i];
                    }

                    arr[i] = arr[i + 1];

                }

                arr[arr.Length - 1] = temp;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
