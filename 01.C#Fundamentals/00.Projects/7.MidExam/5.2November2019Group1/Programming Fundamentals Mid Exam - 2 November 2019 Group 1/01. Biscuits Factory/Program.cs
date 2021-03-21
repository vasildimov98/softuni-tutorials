using System;

namespace _03._Wizard_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfBuiscuitsPerWorker = int.Parse(Console.ReadLine());
            int countOfWorkers = int.Parse(Console.ReadLine());

            int competativeFactoryProduction = int.Parse(Console.ReadLine());

            double totalProduction = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    totalProduction += Math.Floor(0.75 * amountOfBuiscuitsPerWorker * countOfWorkers);
                }
                else
                {
                    totalProduction += amountOfBuiscuitsPerWorker * countOfWorkers;
                }
            }

            Console.WriteLine($"You have produced {totalProduction} biscuits for the past month.");

            double diff = totalProduction - competativeFactoryProduction;

            if (diff > 0)
            {
                double percentageMore = (diff / competativeFactoryProduction) * 100;
                Console.WriteLine($"You produce {percentageMore:F2} percent more biscuits.");
            }
            else
            {
                diff = Math.Abs(diff);
                double percentageLess = (diff / competativeFactoryProduction) * 100;
                Console.WriteLine($"You produce {percentageLess:F2} percent less biscuits.");
            }
        }
    }
}
