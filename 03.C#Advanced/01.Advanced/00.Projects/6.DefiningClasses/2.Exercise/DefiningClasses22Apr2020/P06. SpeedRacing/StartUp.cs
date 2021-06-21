using System;
using System.Collections.Generic;
using System.Linq;

namespace P06._Speed_Racing
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new HashSet<Car>();
            ProcessTheHashSet(n, cars);
            DriveCars(cars);

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private static void DriveCars(HashSet<Car> cars)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var driveArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToArray();

                var modelToDrive = driveArg[0];
                var amountOfKM = int.Parse(driveArg[1]);

                var car = cars
                    .Where(c => c.Model == modelToDrive)
                    .FirstOrDefault();

                if (!car.CanTravel(car, amountOfKM))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
        }

        private static void ProcessTheHashSet(int n, HashSet<Car> cars)
        {
            for (int i = 0; i < n; i++)
            {
                var carArg = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = carArg[0];
                var fuelAmount = double.Parse(carArg[1]);
                var fuelComsumptionPer1KM = double.Parse(carArg[2]);

                var car = new Car(model, fuelAmount, fuelComsumptionPer1KM);

                cars.Add(car);
            }
        }
    }
}
