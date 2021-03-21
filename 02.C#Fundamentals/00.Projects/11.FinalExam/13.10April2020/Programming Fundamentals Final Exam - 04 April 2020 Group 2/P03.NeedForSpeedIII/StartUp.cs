namespace P03.NeedForSpeedIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var cars = new Dictionary<string, int[]>();

            var carToObtain = int.Parse(Console.ReadLine());

            ObtainCars(cars, carToObtain);

            ProceedCommands(cars);

            PrintResult(cars);
        }

        private static void PrintResult(Dictionary<string, int[]> cars)
        {
            var sortedCars = cars
                            .OrderByDescending(c => c.Value[0])
                            .ThenBy(c => c.Key)
                            .ToList();

            foreach (var (model, carInfo) in sortedCars)
            {
                var mileage = carInfo[0];
                var fuel = carInfo[1];

                Console.WriteLine($"{model} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt.");
            }
        }

        private static void ProceedCommands(Dictionary<string, int[]> cars)
        {
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                var args = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = args[0];
                var model = args[1];
                var car = cars[model];

                if (action == "Drive")
                {
                    Drive(cars, args, model, car);
                }
                else if (action == "Refuel")
                {
                    Refuel(args, model, car);
                }
                else
                {
                    Revert(args, model, car);
                }
            }
        }

        private static void Revert(string[] args, string model, int[] car)
        {
            var kilometers = int.Parse(args[2]);

            car[0] -= kilometers;

            var minMileage = 10000;
            if (car[0] < minMileage)
            {
                car[0] = minMileage;
            }
            else
            {
                Console.WriteLine($"{model} mileage decreased by {kilometers} kilometers");
            }
        }

        private static void Refuel(string[] args, string model, int[] car)
        {
            var fuel = int.Parse(args[2]);

            int refueledFuel;
            var tankCapacity = 75;
            if (car[1] + fuel > tankCapacity)
            {
                refueledFuel = tankCapacity - car[1];

                car[1] = tankCapacity;
            }
            else
            {
                refueledFuel = fuel;

                car[1] += fuel;
            }

            Console.WriteLine($"{model} refueled with {refueledFuel} liters");
        }

        private static void Drive(Dictionary<string, int[]> cars, string[] args, string model, int[] car)
        {
            var distance = int.Parse(args[2]);
            var fuel = int.Parse(args[3]);
            var currCarFuel = car[1];

            if (currCarFuel >= fuel)
            {
                car[0] += distance;
                car[1] -= fuel;

                Console.WriteLine($"{model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                if (car[0] >= 100000)
                {
                    cars.Remove(model);

                    Console.WriteLine($"Time to sell the {model}!");
                }
            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
        }

        private static void ObtainCars(Dictionary<string, int[]> cars, int carToObtain)
        {
            for (int i = 0; i < carToObtain; i++)
            {
                var carArgs = Console
                    .ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var car = carArgs[0];
                var mileage = int.Parse(carArgs[1]);
                var fuel = int.Parse(carArgs[2]);

                if (!cars.ContainsKey(car))
                {
                    cars[car] = new int[2] { mileage, fuel };
                }
            }
        }
    }
}
