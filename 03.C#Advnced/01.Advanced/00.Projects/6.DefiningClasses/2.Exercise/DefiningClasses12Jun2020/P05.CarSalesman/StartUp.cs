namespace P05.CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<Engine> engines;
        private static List<Car> cars;
        public static void Main()
        {
            engines = new List<Engine>();
            cars = new List<Car>();

            var countOfEngine = int.Parse(Console.ReadLine());

            GetAllEngines(countOfEngine);

            var countOfCars = int.Parse(Console.ReadLine());

            GetAllCars(countOfCars);

            PrintResult();
        }

        private static void PrintResult()
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void GetAllCars(int countOfCars)
        {
            for (int i = 0; i < countOfCars; i++)
            {
                var carArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = carArgs[0];
                var engineModel = carArgs[1];
                var engine = engines
                    .FirstOrDefault(e => e.Model == engineModel);

                var car = GetCar(carArgs, model, engine);

                cars.Add(car);
            }
        }

        private static Car GetCar(string[] carArgs, string model, Engine engine)
        {
            Car car;
            if (carArgs.Length == 2)
            {
                car = new Car(model, engine);
            }
            else if (carArgs.Length == 3)
            {
                var thirdArgs = carArgs[2];

                if (int.TryParse(thirdArgs, out var weight))
                {
                    car = new Car(model, engine, weight);
                }
                else
                {
                    car = new Car(model, engine, thirdArgs);
                }
            }
            else
            {
                var weight = int.Parse(carArgs[2]);
                var color = carArgs[3];

                car = new Car(model, engine, weight, color);
            }

            return car;
        }

        private static void GetAllEngines(int countOfEngine)
        {
            for (int i = 0; i < countOfEngine; i++)
            {
                var engineArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = engineArgs[0];
                var power = int.Parse(engineArgs[1]);

                var engine = GetEngine(engineArgs, model, power);

                engines.Add(engine);
            }
        }

        private static Engine GetEngine(string[] engineArgs, string model, int power)
        {
            Engine engine;
            if (engineArgs.Length == 2)
            {
                engine = new Engine(model, power);
            }
            else if (engineArgs.Length == 3)
            {
                var thirdArgs = engineArgs[2];

                if (int.TryParse(thirdArgs, out var displacement))
                {
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    engine = new Engine(model, power, thirdArgs);
                }
            }
            else
            {
                var displacement = int.Parse(engineArgs[2]);
                var efficiency = engineArgs[3];

                engine = new Engine(model, power, displacement, efficiency);
            }

            return engine;
        }
    }
}
