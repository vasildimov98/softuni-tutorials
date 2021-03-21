namespace P01.Vehicle.Core
{
    using System;
    using System.Linq;

    using Models.Contracts;
    using P01.Vehicle.Models;

    public class Engine : IEngine
    {
        private IVehicle car;
        private IVehicle truck;
        private IVehicle bus;
        public void Run()
        {
            this.InstanciateObject();
            this.SeekAction();
            this.PrintResult();
        }

        private void PrintResult()
        {
            Console.WriteLine(this.car);
            Console.WriteLine(this.truck);
            Console.WriteLine(this.bus);
        }

        private void SeekAction()
        {
            var numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var actionArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var action = actionArgs[0] + ' ' + actionArgs[1];
                var methodParameter = double.Parse(actionArgs[2]);

                try
                {
                    this.ProceedAction(action, methodParameter);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private void ProceedAction(string action, double methodParameter)
        {
            if (action == "Drive Car")
            {
                Console.WriteLine(this.car.Drive(methodParameter));
            }
            else if (action == "Drive Truck")
            {
                Console.WriteLine(this.truck.Drive(methodParameter));
            }
            else if (action == "Drive Bus")
            {
                Console.WriteLine((this.bus as Bus).DriveWithPeople(methodParameter));
            }
            else if (action == "DriveEmpty Bus")
            {
                Console.WriteLine(this.bus.Drive(methodParameter));
            }
            else if (action == "Refuel Car")
            {
                this.car.Refuel(methodParameter);
            }
            else if (action == "Refuel Truck")
            {
                this.truck.Refuel(methodParameter);
            }
            else
            {
                this.bus.Refuel(methodParameter);
            }
        }

        private void InstanciateObject()
        {
            var carArgs = this.ReadInput();

            var carFuelQuantity = carArgs[0];
            var carLitersPerKm = carArgs[1];
            var carTankCapacity = (int)carArgs[2];

            this.car = new Car(carTankCapacity, carFuelQuantity, carLitersPerKm);

            var truckArgs = this.ReadInput();

            var truckFuelQuantity = truckArgs[0];
            var truckLitersPerKm = truckArgs[1];
            var truckTankCapacity = (int)truckArgs[2];

            this.truck = new Truck(truckTankCapacity, truckFuelQuantity, truckLitersPerKm);

            var busArgs = this.ReadInput();

            var busFuelQuantity = busArgs[0];
            var busLitersPerKm = busArgs[1];
            var busTankCapacity = (int)busArgs[2];

            this.bus = new Bus(busTankCapacity, busFuelQuantity, busLitersPerKm);
        }

        private double[] ReadInput()
        {
            return Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(double.Parse)
                .ToArray();
        }
    }
}
