using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.RawData
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new HashSet<Car>();
            ProcessListOfCars(n, cars);

            var finalCommand = Console.ReadLine();
            string result = GetResult(ref cars, finalCommand);

            Console.WriteLine(result);
        }

        private static string GetResult(ref HashSet<Car> cars, string finalCommand)
        {
            var result = string.Empty;
            if (finalCommand == "fragile")
            {
                cars = cars
                    .Where(c => c.Cargo.Type == finalCommand &&
                            c.Tires.Any(p => p.Pressure < 1))
                    .ToHashSet();

                result = string.Join(Environment.NewLine, cars);
            }
            else if (finalCommand == "flamable")
            {
                cars = cars
                    .Where(c => c.Cargo.Type == finalCommand &&
                    c.Engine.Power > 250)
                    .ToHashSet();

                result = string.Join(Environment.NewLine, cars);
            }

            return result;
        }

        private static void ProcessListOfCars(int n, HashSet<Car> cars)
        {
            for (int i = 0; i < n; i++)
            {
                var carArg = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = carArg[0];

                var engineSpeed = int.Parse(carArg[1]);
                var enginePower = int.Parse(carArg[2]);

                var cargoWeight = int.Parse(carArg[3]);
                var cargoType = carArg[4];

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);

                var listOfTires = new List<Tire>();
                ProccessListOfTires(carArg, listOfTires);

                var car = new Car(model, engine, cargo, listOfTires);
                cars.Add(car);
            }
        }

        private static void ProccessListOfTires(string[] carArg, List<Tire> listOfTires)
        {
            for (int j = 5; j < carArg.Length; j += 2)
            {
                var tirePressure = double.Parse(carArg[j]);
                var tireAge = int.Parse(carArg[j + 1]);

                var tire = new Tire(tirePressure, tireAge);

                listOfTires.Add(tire);
            }
        }
    }
}
