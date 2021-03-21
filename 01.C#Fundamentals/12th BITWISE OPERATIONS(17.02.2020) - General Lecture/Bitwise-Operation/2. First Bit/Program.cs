using System;
using System.Linq;

namespace _2._First_Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string binary = Convert.ToString(n, 2).ToString();

            char[] arr = binary.ToCharArray().Reverse().ToArray();

            Console.WriteLine(arr[1]);
        }
    }
}
