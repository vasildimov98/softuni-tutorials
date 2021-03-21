using System;
using System.Collections.Generic;

namespace _03._Speed_Racing
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console
                    .ReadLine()
                    .Split();

                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumptionFor1km = double.Parse(data[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);

                cars.Add(car);
            }

            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                    .Split();

                string model = data[1];
                double amountOfKm = double.Parse(data[2]);

                foreach (var car in cars)
                {
                    if (car.Model == model)
                    {
                        car.TrayTravelDistance(amountOfKm);
                        break;
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelDistance}");
            }
        }
    }

    class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer  { get; set; }
        public double  TravelDistance { get; set; }

        public void TrayTravelDistance(double amountOfKm)
        {
            double fuelNeeded = amountOfKm * FuelConsumptionPerKilometer;

            if (FuelAmount >= fuelNeeded)
            {
                TravelDistance += amountOfKm;
                FuelAmount -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
