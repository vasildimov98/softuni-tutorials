using System;

namespace _01._Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double priceFor1KgFlour = double.Parse(Console.ReadLine());

            double priceForEggs = priceFor1KgFlour * 0.75;
            double priceForMilk = (priceFor1KgFlour * 1.25) * 0.25;
           
            double totalPrice = priceFor1KgFlour + priceForEggs + priceForMilk;

            int countCozonacs = (int)(budget / totalPrice);
            budget -= countCozonacs * totalPrice;
            int countOFColorEggs = 0;
            for (int i = 1; i <= countCozonacs; i++)
            {
                countOFColorEggs += 3;

                if (i % 3 == 0)
                {
                    countOFColorEggs -= i - 2;
                }
            }

            Console.WriteLine($"You made {countCozonacs} cozonacs! Now you have {countOFColorEggs} eggs and {budget:F2}BGN left.");
        }
    }
}
