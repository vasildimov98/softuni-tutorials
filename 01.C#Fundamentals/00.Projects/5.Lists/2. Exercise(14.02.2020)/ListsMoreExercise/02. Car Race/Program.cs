using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main()
        {
            int[] cource = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int middleIndex = cource.Length / 2;

            double car1Time = GetTimeForCar1(cource, middleIndex);
            double car2Time = GetTimeForCar2(cource, middleIndex);

            if (car1Time < car2Time)
            {
                Console.WriteLine($"The winner is left with total time: {car1Time}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {car2Time}");
            }
        }

        private static double GetTimeForCar2(int[] cource, int middleIndex)
        {
            List<int> car2 = new List<int>();

            for (int i = cource.Length - 1; i > middleIndex; i--)
            {
                car2.Add(cource[i]);
            }

            double car2Time = 0;
            for (int i = 0; i < car2.Count; i++)
            {
                int currTime = car2[i];

                if (currTime == 0)
                {
                    car2Time *= 0.80;
                    car2Time = Math.Round(car2Time, 1);
                }
                else
                {
                    car2Time += currTime;
                }
            }

            return car2Time;
        }

        private static double GetTimeForCar1(int[] cource, int middleIndex)
        {
            List<int> car1 = new List<int>();

            for (int i = 0; i < middleIndex; i++)
            {
                car1.Add(cource[i]);
            }

            double car1Time = 0;
            for (int i = 0; i < car1.Count; i++)
            {
                int currTime = car1[i];

                if (currTime == 0)
                {
                    car1Time *= 0.80;
                    car1Time = Math.Round(car1Time, 1);
                }
                else
                {
                    car1Time += currTime;
                }
            }

            return car1Time;
        }
    }
}
