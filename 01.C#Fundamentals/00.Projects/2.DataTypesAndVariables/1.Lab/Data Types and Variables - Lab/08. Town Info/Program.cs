using System;

namespace _08._Town_Info
{
    class Program
    {
        private static object population;

        static void Main(string[] args)
        {
            string townnName = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            double area = double.Parse(Console.ReadLine());

            Console.WriteLine($"Town {townnName} has population of {population} and area {area} square km.");
        }
    }
}
