using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Type> cars = new List<Type>();
            List<Type> trucks = new List<Type>();

            while ((command = Console.ReadLine()) != "End")
            {
                string[] inputs = command
                    .Split();

                string typeOfVehicle = inputs[0];
                string modelOfVehicle = inputs[1];
                string colorOfVehicle = inputs[2];
                double horsePowerOfVehicle = double.Parse(inputs[3]);

                Type type = new Type(typeOfVehicle, modelOfVehicle, colorOfVehicle, horsePowerOfVehicle);

                if (typeOfVehicle == "car")
                {
                    cars.Add(type);
                }
                else
                {
                    trucks.Add(type);
                }

                CatalogOfVehicle catalog = new CatalogOfVehicle(cars, trucks);
            }

            string command1 = "";

            while ((command1 = Console.ReadLine()) != "Close the Catalogue")
            {
                if (cars.Find(m => m.Model == command1) != null)
                {
                    List<Type> currentModelList = cars
                        .Where(m => m.Model == command1)
                        .ToList();

                    Console.WriteLine($"Type: Car");
                    Console.WriteLine($"Model: {currentModelList[0].Model}");
                    Console.WriteLine($"Color: {currentModelList[0].Color}");
                    Console.WriteLine($"Horsepower: {currentModelList[0].HorsePower}");
                }
                else if (trucks.Find(m => m.Model == command1) != null)
                {
                    List<Type> currentModelList = trucks
                        .Where(m => m.Model == command1)
                        .ToList();

                    Console.WriteLine($"Type: Truck");
                    Console.WriteLine($"Model: {currentModelList[0].Model}");
                    Console.WriteLine($"Color: {currentModelList[0].Color}");
                    Console.WriteLine($"Horsepower: {currentModelList[0].HorsePower}");
                }
            }

            double sumHorsePowerCars = 0;

            foreach (var car in cars)
            {
                sumHorsePowerCars += car.HorsePower;
            }

            double sumHorsePowerTrucks = 0;

            foreach (var truck in trucks)
            {
                sumHorsePowerTrucks += truck.HorsePower;
            }

            double avrHorPowCars = sumHorsePowerCars / cars.Count;
            double avrHorPowTrucks = sumHorsePowerTrucks / trucks.Count;

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {avrHorPowCars:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {avrHorPowTrucks:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }
    }

    class Type
    {
        public Type(string typeOfVehicle, string model, string color, double horsePower)
        {
            TypeOfVehicle = typeOfVehicle;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string TypeOfVehicle { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
    }

    class CatalogOfVehicle
    {
        public CatalogOfVehicle(List<Type> car, List<Type> truck)
        {
            Car = car;
            Truck = truck;
        }

        public List<Type> Car { get; set; }
        public List<Type> Truck { get; set; }
    }
}
