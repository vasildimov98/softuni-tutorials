namespace P04.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private const int COUNT_OF_TIRES = 4;

        private static List<Car> cars;
        public static void Main()
        {
            cars = new List<Car>();

            var countOfInput = int.Parse(Console.ReadLine());

            GetAllCars(countOfInput);

            var finalCommand = Console.ReadLine();

            PrintFinalResult(finalCommand);
        }

        private static void PrintFinalResult(string finalCommand)
        {
            if (finalCommand == "fragile")
            {
                var frigileCars = cars
                    .Where(c => c.Cargo.Type == finalCommand)
                    .Where(c => c.Tires.Any(t => t.Pressure < 1));

                Console.WriteLine(string.Join(Environment.NewLine, frigileCars));
            }
            else
            {
                var flamableCars = cars
                    .Where(c => c.Cargo.Type == finalCommand)
                    .Where(c => c.Engine.Power > 250);

                Console.WriteLine(string.Join(Environment.NewLine, flamableCars));
            }
        }

        private static void GetAllCars(int countOfInput)
        {
            for (int i = 0; i < countOfInput; i++)
            {
                var args = Console
                    .ReadLine()
                    .Split()
                    .ToArray();

                var model = args[0];

                var engineSpeed = int.Parse(args[1]);
                var enginePower = int.Parse(args[2]);
                var engine = new Engine(engineSpeed, enginePower);

                var cargoWeight = int.Parse(args[3]);
                var cargoType = args[4];
                var cargo = new Cargo(cargoWeight, cargoType);

                var tires = new Tire[COUNT_OF_TIRES];
                GetAllTires(args, tires);

                var car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }
        }

        private static void GetAllTires(string[] args, Tire[] tires)
        {
            var currIndex = 0;
            for (int index = 5; index < args.Length; index += 2)
            {
                var pressure = double.Parse(args[index]);
                var age = int.Parse(args[index + 1]);

                var tire = new Tire(pressure, age);

                tires[currIndex++] = tire;
            }
        }
    }
}
