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

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double firstPoint = Math.Abs(x1) + Math.Abs(y1) + Math.Abs(x2) + Math.Abs(y2);
            double secondPoint = Math.Abs(x3) + Math.Abs(y3) + Math.Abs(x4) + Math.Abs(y4);

            if (firstPoint > secondPoint)
            {
                firstPoint = Math.Abs(x1) + Math.Abs(y1);
                secondPoint = Math.Abs(x2) + Math.Abs(y2);

                if (firstPoint < secondPoint)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else if (firstPoint > secondPoint)
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
                else
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
            }
            else if (firstPoint < secondPoint)
            {
                firstPoint = Math.Abs(x3) + Math.Abs(y3);
                secondPoint = Math.Abs(x4) + Math.Abs(y4);

                if (firstPoint < secondPoint)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else if (firstPoint > secondPoint)
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
                else
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
            }
            else
            {
                firstPoint = Math.Abs(x1) + Math.Abs(y1);
                secondPoint = Math.Abs(x2) + Math.Abs(y2);

                if (firstPoint < secondPoint)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else if (firstPoint > secondPoint)
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
                else
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
            }
        }
    }
}
