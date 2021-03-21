using System;
using System.Linq;

namespace _3._p_th_Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            string binary = Convert.ToString(n, 2).ToString();

            char[] arr = binary.ToCharArray().Reverse().ToArray();

            if (p < arr.Length)
            {
                Console.WriteLine(arr[p]);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
