using System;

namespace _02._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintResult();
        }

        private static void PrintResult()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double firstPoint = Math.Abs(x1) + Math.Abs(y1);
            double secondPoint = Math.Abs(x2) + Math.Abs(y2);

            if (firstPoint < secondPoint)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (firstPoint > secondPoint)
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x1}, {y1})");
            }
        }
    }
}
