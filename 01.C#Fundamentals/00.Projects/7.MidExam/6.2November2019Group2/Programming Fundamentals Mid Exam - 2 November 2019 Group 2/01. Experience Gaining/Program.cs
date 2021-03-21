using System;

namespace _01._Experience_Gaining
{
    class Program
    {
        static void Main()
        {
            double neededExperience = double.Parse(Console.ReadLine());

            int countOfBettles = int.Parse(Console.ReadLine());

            for (int i = 1; i <= countOfBettles; i++)
            {
                double experienceEarned = double.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    experienceEarned *= 1.15;
                }
                else if (i % 5 == 0)
                {
                    experienceEarned *= 0.9;
                }

                neededExperience -= experienceEarned;

                if (neededExperience <= 0)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {i} battles.");
                    return;
                }
            }

            Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience:F2} more needed.");
        }
    }
}
