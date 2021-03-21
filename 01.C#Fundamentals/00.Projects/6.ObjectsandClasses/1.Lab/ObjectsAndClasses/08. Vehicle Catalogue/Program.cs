using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            input = GetCarAndTruckLists(cars, trucks);

            cars = cars.OrderBy(b => b.Brand).ToList();
            trucks = trucks.OrderBy(b => b.Brand).ToList();

            if (cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");

                foreach (var truck in trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }

        private static string GetCarAndTruckLists(List<Car> cars, List<Truck> trucks)
        {
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> informationList = input
                    .Split("/")
                    .ToList();

                string carOrTruck = informationList[0];

                if (carOrTruck == "Car")
                {
                    Car car = new Car(informationList[1], informationList[2], informationList[3]);
                    cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck(informationList[1], informationList[2], informationList[3]);
                    trucks.Add(truck);
                }

                CatalogVehicle catalogVehicle = new CatalogVehicle(cars, trucks);
            }

            return input;
        }
    }

    class Truck
    {
        public Truck(string brand, string model, string weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }

    }

    class Car
    {
        public Car(string brand, string model, string horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }

    class CatalogVehicle
    {
        public CatalogVehicle(List<Car> cars, List<Truck> trucks)
        {
            Cars = cars;
            Trucks = trucks;
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }

}
