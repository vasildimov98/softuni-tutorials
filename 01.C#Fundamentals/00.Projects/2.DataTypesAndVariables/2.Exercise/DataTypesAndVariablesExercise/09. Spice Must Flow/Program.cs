using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startYield = int.Parse(Console.ReadLine());
            int day = 0;
            int totalSpice = 0;

            while (startYield >= 100)
            {
                totalSpice += startYield;

                if (totalSpice >= 26)
                {
                    totalSpice -= 26;
                }
                
                startYield -= 10;
                day++;
            }

            if (totalSpice >= 26)
            {
                totalSpice -= 26;
            }

            Console.WriteLine(day);
            Console.WriteLine(totalSpice);

        }
    }
}
