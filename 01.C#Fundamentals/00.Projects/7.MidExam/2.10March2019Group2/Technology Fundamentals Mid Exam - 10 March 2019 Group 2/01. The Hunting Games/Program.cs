using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfAdvenger = int.Parse(Console.ReadLine());
            int countOfPlayers = int.Parse(Console.ReadLine());
            double totalEnergy = double.Parse(Console.ReadLine());

            double waterPerPerson = double.Parse(Console.ReadLine());
            double foodPerPerson = double.Parse(Console.ReadLine());

            double totalWater = countOfPlayers * waterPerPerson * daysOfAdvenger;
            double totalFood = countOfPlayers * foodPerPerson * daysOfAdvenger;
            for (int i = 1; i <= daysOfAdvenger; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                totalEnergy -= energyLoss;

                if (totalEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
                    return;
                }

                if (i % 2 == 0)
                {
                    totalEnergy *= 1.05;
                    totalWater *= 0.70;
                }

                if (i % 3 == 0)
                {
                    totalEnergy *= 1.10;
                    totalFood -= totalFood / countOfPlayers;
                }
            }

            Console.WriteLine($"You are ready for the quest. You will be left with - {totalEnergy:F2} energy!");
        }
    }
}
