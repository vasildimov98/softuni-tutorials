using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            double result = GetSmallest(num1, num2, num3);
            Console.WriteLine(result);
        }

        static int GetSmallest(int num1, int num2, int num3)
        {
            int result = 0;
            result = Math.Min(Math.Min(num1, num2), num3);
            return result;
        }
    }
}
