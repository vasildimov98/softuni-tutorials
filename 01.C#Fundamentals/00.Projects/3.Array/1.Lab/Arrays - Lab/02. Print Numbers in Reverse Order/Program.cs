using System;

namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrays = new int[n];

            for (int i = 0; i < arrays.Length; i++)
            {
                arrays [i] = int.Parse(Console.ReadLine());
            }

            for (int i = arrays.Length - 1; i >= 0; i--)
            {
                Console.Write(arrays[i] + " ");
            }
           
        }
    }
}
