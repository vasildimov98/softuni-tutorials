using System;

namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double num3 = double.Parse(Console.ReadLine());

            double largestNum = Math.Max(Math.Max(num1, num2), num3);
            double smallestNum = Math.Min(Math.Min(num1, num2), num3);
            double middleNum = (num1 + num2 + num3) - (largestNum + smallestNum);

            Console.WriteLine(largestNum);
            Console.WriteLine(middleNum);
            Console.WriteLine(smallestNum);
        }
    }
}
