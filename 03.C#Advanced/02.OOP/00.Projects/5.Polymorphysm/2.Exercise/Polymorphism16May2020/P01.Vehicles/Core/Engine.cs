namespace P01.Vehicles.Core
{
    using System;
    using System.Linq;

    using P01.Vehicles.Modules;
    using P01.Vehicles.IO.Contracts;
    using P01.Vehicles.Contracts;

    public class Engine : IEngine
    {
        private Vehicle car;
        private Vehicle truck;
        private Vehicle bus;

        private IReadable reader;
        private IWritable writer;

        public Engine(IReadable reader, IWritable writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {

            ProduceVehicle();
            ProduceVehicle();
            ProduceVehicle();

            var numberOfCommands = int.Parse(reader.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {
                    ProceedVehicle();
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                }
            }

            PrintResult();
        }

        private void ProceedVehicle()
        {
            var command = reader
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var action = command[0];

            var vehicle = command[1];
            var arg = double.Parse(command[2]);

            if (action == "Drive")
            {
                DriveVehicle(vehicle, arg);
            }
            else if (action == "DriveEmpty")
            {
                writer.WriteLine(this.bus.DriveEmpty(arg));
            }
            else if (action == "Refuel")
            {
                RefuelVehicle(vehicle, arg);
            }
        }

        private void RefuelVehicle(string vehicle, double arg)
        {
            if (vehicle == "Car")
            {
                this.car.Refuel(arg);
            }
            else if (vehicle == "Truck")
            {
                this.truck.Refuel(arg);
            }
            else if (vehicle == "Bus")
            {
                this.bus.Refuel(arg);
            }
        }

        private void DriveVehicle(string vehicle, double arg)
        {
            if (vehicle == "Car")
            {
                writer.WriteLine(this.car.Drive(arg));
            }
            else if (vehicle == "Truck")
            {
                writer.WriteLine(this.truck.Drive(arg));
            }
            else if (vehicle == "Bus")
            {
                writer.WriteLine(this.bus.Drive(arg));
            }
        }

        private void PrintResult()
        {
            writer.WriteLine(this.car.ToString());
            writer.WriteLine(this.truck.ToString());
            writer.WriteLine(this.bus.ToString());
        }

        private void ProduceVehicle()
        {
            var vehicleArg = reader
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var type = vehicleArg[0];
            var fuelQuantity = double.Parse(vehicleArg[1]);
            var fuelConsumption = double.Parse(vehicleArg[2]);
            var tankCapacity = double.Parse(vehicleArg[3]);

            if (fuelQuantity > tankCapacity)
            {
                fuelQuantity = 0;
            }

            ProcceedType(type, fuelQuantity, fuelConsumption, tankCapacity);
        }

        private void ProcceedType(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (type == "Car")
            {
                this.car = VehicleCreater.Create(type,
                fuelQuantity,
                fuelConsumption,
                tankCapacity);
            }
            else if (type == "Truck")
            {
                this.truck = VehicleCreater.Create(type,
                fuelQuantity,
                fuelConsumption,
                tankCapacity);
            }
            else if (type == "Bus")
            {
                this.bus = VehicleCreater.Create(type,
                fuelQuantity,
                fuelConsumption,
                tankCapacity);
            }
        }
    }
}
