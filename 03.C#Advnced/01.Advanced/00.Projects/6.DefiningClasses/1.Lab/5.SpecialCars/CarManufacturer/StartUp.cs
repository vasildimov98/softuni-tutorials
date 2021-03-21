using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var tiresList = new List<Tire[]>();
            string command;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                var cmdArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var tiresArr = new Tire[cmdArg.Length / 2];
                int count = 0;
                for (int i = 0; i < cmdArg.Length; i += 2)
                {
                    var year = int.Parse(cmdArg[i]);
                    var pressure = double.Parse(cmdArg[i + 1]);

                    var tire = new Tire(year, pressure);
                    tiresArr[count++] = tire;
                }

                tiresList.Add(tiresArr);
            }

            var enginesList = new List<Engine>();
            while ((command = Console.ReadLine()) != "Engines done")
            {
                var cmdArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < cmdArg.Length; i += 2)
                {
                    var horsePower = int.Parse(cmdArg[i]);
                    var cubicCapacity = double.Parse(cmdArg[i + 1]);

                    var engine = new Engine(horsePower, cubicCapacity);

                    enginesList.Add(engine);
                }
            }

            var carsList = new List<Car>();
            while ((command = Console.ReadLine()) != "Show special")
            {
                var cmdArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var make = cmdArg[0];
                var model = cmdArg[1];
                var year = int.Parse(cmdArg[2]);
                var fuelQuantity = double.Parse(cmdArg[3]);
                var fuelComsumption = double.Parse(cmdArg[4]);

                var engineIndex = int.Parse(cmdArg[5]);
                var tiresIndex = int.Parse(cmdArg[6]);

                var engine = enginesList[engineIndex];
                var tires = tiresList[tiresIndex];

                var car = new Car(
                    make,
                    model,
                    year,
                    fuelQuantity,
                    fuelComsumption,
                    engine,
                    tires);

                carsList.Add(car);
            }

            var predicate = ValidateCar();
            var specialCarList = new List<Car>();
            foreach (var car in carsList)
            {
                if (predicate(car))
                {
                    car.Drive(20);
                    specialCarList.Add(car);
                }
            }

            foreach (var car in specialCarList)
            {
                Console.WriteLine(car.SpecialCarsInformation());
            }
        }

        static Predicate<Car> ValidateCar()
        {
            Predicate<Car> predicate = x =>
            {
                if (x.Year >= 2017 && x.Engine.HorsePower > 330)
                {
                    var sum = 0D;
                    foreach (var tire in x.Tires)
                    {
                        sum += tire.Pressure;
                    }

                    if (sum >= 9 && sum <= 10)
                    {
                        return true;
                    }
                }

                return false;
            };

            return predicate;
        }
    }
}
