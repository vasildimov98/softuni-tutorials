namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<Tire[]> tires;
        private static List<Engine> engines;
        private static List<Car> cars;

        public static void Main()
        {
            tires = new List<Tire[]>();
            engines = new List<Engine>();
            cars = new List<Car>();

            GetAllTires();
            GetAllEngines();
            GetAllCars();

            var specialCars = cars
                .Where(c => c.Year >= 2017)
                .Where(c => c.Engine.HorsePower > 330)
                .Where(c => c.Tires.Sum(t => t.Pressure) >= 9)
                .Where(c => c.Tires.Sum(t => t.Pressure) <= 10)
                .ToArray();

            DriveAllSpecialCars(specialCars);
            PrintSpecialCars(specialCars);
        }

        private static void PrintSpecialCars(Car[] specialCars)
        {
            foreach (var specialCar in specialCars)
            {
                Console.WriteLine(specialCar);
            }
        }

        private static void DriveAllSpecialCars(Car[] specialCars)
        {
            foreach (var specialCar in specialCars)
            {
                var twentyKm = 20;
                specialCar.Drive(twentyKm);
            }
        }

        private static void GetAllCars()
        {
            string command;
            while ((command = Console.ReadLine()) != "Show special")
            {
                var carArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var carMake = carArgs[0];
                var carModel = carArgs[1];
                var carYear = int.Parse(carArgs[2]);
                var carFuelQuantity = double.Parse(carArgs[3]);
                var carFuelConsumption = double.Parse(carArgs[4]);

                var engineIndex = int.Parse(carArgs[5]);
                var tiresIndex = int.Parse(carArgs[6]);

                var currEngine = engines[engineIndex];
                var currTires = tires[tiresIndex];

                var currCar = new Car(carMake,
                    carModel,
                    carYear,
                    carFuelQuantity,
                    carFuelConsumption,
                    currEngine,
                    currTires);

                cars.Add(currCar);
            }
        }

        private static void GetAllEngines()
        {
            string command;
            while ((command = Console.ReadLine()) != "Engines done")
            {
                var engineArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var horsePower = int.Parse(engineArgs[0]);
                var cubicCapacity = double.Parse(engineArgs[1]);

                var engine = new Engine(horsePower, cubicCapacity);

                engines.Add(engine);
            }
        }

        private static void GetAllTires()
        {
            string command;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                var tireArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var tiresInfo = new Tire[tireArgs.Length / 2];

                var index = 0;
                for (int i = 0; i < tireArgs.Length; i += 2)
                {
                    var year = int.Parse(tireArgs[i]);
                    var pressure = double.Parse(tireArgs[i + 1]);

                    var tire = new Tire(year, pressure);

                    tiresInfo[index++] = tire;
                }

                tires.Add(tiresInfo);
            }
        }

        private static void CreateFourCars()
        {
            var make = Console.ReadLine();
            var model = Console.ReadLine();
            var year = int.Parse(Console.ReadLine());
            var fuelQuantity = double.Parse(Console.ReadLine());
            var fuelConsumption = double.Parse(Console.ReadLine());
            var engine = new Engine(560, 6300);
            var tires = new[]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)
            };

            var firstCar = new Car();
            var secondCar = new Car(make, model, year);
            var thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
            var fourthCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tires);

            Console.WriteLine(firstCar.WhoAmI());
            Console.WriteLine("==================================");
            Console.WriteLine(secondCar.WhoAmI());
            Console.WriteLine("==================================");
            Console.WriteLine(thirdCar.WhoAmI());
            Console.WriteLine("==================================");
            Console.WriteLine(fourthCar.WhoAmI());
        }
    }
}
