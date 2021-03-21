using System;
using System.Collections.Generic;

namespace _07_RawData
{
    class Program
    {
        static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] data = Console
                    .ReadLine()
                    .Split();

                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                string model = data[0];

                Car car = new Car(model, engine, cargo);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car car in cars)
                {
                    if (car.Cargo.CargoType == "fragile" && car.Cargo.CargoWeight < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (command == "flamable")
            {
                foreach (Car car in cars)
                {
                    if (car.Cargo.CargoType == "flamable" && car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }

    class Car
    {
        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
    }

    class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
        }

        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }

    class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }

        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
}