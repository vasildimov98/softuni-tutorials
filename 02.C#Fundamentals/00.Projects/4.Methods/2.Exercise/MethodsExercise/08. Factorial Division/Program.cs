using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());

            double factFirst = Factorial(first);
            double factSecond = Factorial(second);

            double result = factFirst / factSecond;
            Console.WriteLine($"{result:F2}");
        }

        static double Factorial(double number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}
