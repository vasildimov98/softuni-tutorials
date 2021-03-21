using System;

namespace _01._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyCost = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());

            double savedMoney = journeyCost * 0.25;

            for (int i = 2; i <= months; i++)
            {
                if (i % 2 != 0)
                {
                    savedMoney -= savedMoney * 0.16;
                }

                if (i % 4 == 0)
                {
                    savedMoney += savedMoney * 0.25;
                }

                savedMoney += journeyCost * 0.25;
            }

            double diff = savedMoney - journeyCost;

            if (diff >= 0)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {diff:F2}lv. for souvenirs.");
            }
            else
            {
                diff = Math.Abs(diff);
                Console.WriteLine($"Sorry. You need {diff:F2}lv. more.");
            }
        }
    }
}
