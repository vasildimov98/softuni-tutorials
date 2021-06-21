using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.CarSalesman
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            GetAllEngine(n, engines);

            var m = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            GetAllCars(engines, m, cars);

            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

        private static void GetAllCars(List<Engine> engines, int m, List<Car> cars)
        {
            for (int i = 0; i < m; i++)
            {
                var carArg = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = carArg[0];
                var engineModel = carArg[1];
                var engine = engines
                    .Where(e => e.Model == engineModel)
                    .FirstOrDefault();

                var car = new Car(model, engine);
                car = GetCurrentCar(carArg, model, engine, car);
                cars.Add(car);
            }
        }

        private static Car GetCurrentCar(string[] carArg, string model, Engine engine, Car car)
        {
            if (carArg.Length == 3)
            {
                int weight;
                var tryParse = int.TryParse(carArg[2], out weight);

                if (tryParse)
                {
                    car = new Car(model, engine, weight);
                }
                else
                {
                    var color = carArg[2];
                    car = new Car(model, engine, color);
                }
            }
            else if (carArg.Length == 4)
            {
                var weight = int.Parse(carArg[2]);
                var color = carArg[3];

                car = new Car(model, engine, weight, color);
            }

            return car;
        }

        private static void GetAllEngine(int n, List<Engine> engines)
        {
            for (int i = 0; i < n; i++)
            {
                var engineArg = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var model = engineArg[0];
                var power = int.Parse(engineArg[1]);

                var engine = (Engine)null;
                engine = GetCurrentEngine(engineArg, model, power, engine);

                if (engine != null)
                {
                    engines.Add(engine);
                }
            }
        }

        private static Engine GetCurrentEngine(string[] engineArg, string model, int power, Engine engine)
        {
            if (engineArg.Length == 2)
            {
                engine = new Engine(model, power);
            }
            else if (engineArg.Length == 3)
            {
                int displacement;

                var tryParse = int.TryParse(engineArg[2], out displacement);

                if (tryParse)
                {
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    var efficiency = engineArg[2];

                    engine = new Engine(model, power, efficiency);
                }
            }
            else if (engineArg.Length == 4)
            {
                var displacement = int.Parse(engineArg[2]);
                var efficiency = engineArg[3];

                engine = new Engine(model, power, displacement, efficiency);
            }

            return engine;
        }
    }
}
