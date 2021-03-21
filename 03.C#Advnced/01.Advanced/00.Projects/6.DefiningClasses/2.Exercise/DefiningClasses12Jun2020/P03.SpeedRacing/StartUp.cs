namespace P03.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;

    public class StartUp
    {
        private static List<Car> cars;

        public static void Main()
        {
            cars = new List<Car>();

            var numOfCars = int.Parse(Console.ReadLine());

            GetAllCars(numOfCars);

            DriveCars();

            PrintCars();
        }

        private static void PrintCars()
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void DriveCars()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var carArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = carArgs[1];
                var distance = double.Parse(carArgs[2]);

                var car = cars
                    .FirstOrDefault(c => c.Model == model);

                car.Drive(distance);
            }
        }

        private static void GetAllCars(int numOfCars)
        {
            for (int i = 0; i < numOfCars; i++)
            {
                var carArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = carArgs[0];
                var fuelAmount = double.Parse(carArgs[1]);
                var fuelConsumptionFor1km = double.Parse(carArgs[2]);

                var car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(car);
            }
        }
    }
}
