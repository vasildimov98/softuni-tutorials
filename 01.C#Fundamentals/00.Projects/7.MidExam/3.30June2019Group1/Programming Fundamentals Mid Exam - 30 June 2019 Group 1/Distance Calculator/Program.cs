using System;

namespace Distance_Calculator
{
    class Program
    {
        static void Main()
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double oneStepLengthCentimeters = double.Parse(Console.ReadLine());
            int distanceInMeter = int.Parse(Console.ReadLine());

            int slowSteps = stepsMade / 5;
            stepsMade -= slowSteps;
            double distanceMadeByMe = (oneStepLengthCentimeters * stepsMade) + ((oneStepLengthCentimeters * 0.70) * slowSteps); ;

            double myDistanceInMeters = distanceMadeByMe / 100;

            double persentege = (myDistanceInMeters / distanceInMeter) * 100;

            Console.WriteLine($"You travelled {persentege:F2}% of the distance!");
        }
    }
}
