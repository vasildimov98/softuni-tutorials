using System;
using System.Linq;

namespace _1._Binary_Digits_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int zeroOrOne = int.Parse(Console.ReadLine());

            int count = 0;
            while (n != 0)
            {
                int digit = n % 2;

                if (digit == zeroOrOne)
                {
                    count++;
                }
                n /= 2;
            }
            Console.WriteLine(count);
        }
    }
}
