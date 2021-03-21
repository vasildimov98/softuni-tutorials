using System;
using System.Linq;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int[] arr = new int[3]
                {
                    num1,
                    num2,
                    num3
                };

            if (num1 == 0 || num2 == 0 || num3 == 0)
            {
                Console.WriteLine("zero");
            }
            else if (arr.Where(a => a < 0).ToArray().Length == 1 || arr.Where(a => a < 0).ToArray().Length == 3)
            {
                Console.WriteLine("negative");
            }
            else
            {
                Console.WriteLine("positive");
            }
        }
    }
}
