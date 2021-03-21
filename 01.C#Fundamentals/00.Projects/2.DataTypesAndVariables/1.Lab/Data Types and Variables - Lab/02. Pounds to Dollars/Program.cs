using System;

namespace _02._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double britishPound = double.Parse(Console.ReadLine());

            double usaDollars = britishPound * 1.31;

            Console.WriteLine($"{usaDollars:F3}");
        }
    }
}
