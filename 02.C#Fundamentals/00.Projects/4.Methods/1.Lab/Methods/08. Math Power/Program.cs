﻿using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double pow = double.Parse(Console.ReadLine());
            double result = NumPower(num, pow);
            Console.WriteLine(result);
        }

        static double NumPower(double num, double pow)
        {
            double result = 1;
            for (double i = 0; i < pow; i++)
            {
                result *= num;
            }
            return result;
        }
    }
}
