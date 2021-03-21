using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = 255;

            int nLines = int.Parse(Console.ReadLine());

            int capacity = 0;
            for (int i = 0; i < nLines; i++)
            {
                int litterWater = int.Parse(Console.ReadLine());

                if (litterWater <= maxCapacity)
                {
                    maxCapacity -= litterWater;
                    capacity += litterWater;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(capacity);
        }
    }
}
