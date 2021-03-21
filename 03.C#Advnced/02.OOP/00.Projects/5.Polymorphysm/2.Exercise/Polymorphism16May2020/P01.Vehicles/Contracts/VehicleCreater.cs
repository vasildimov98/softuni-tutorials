namespace P01.Vehicles.Contracts
{
    using System;

    using P01.Vehicles.Modules;

    public static class VehicleCreater
    {
        public static Vehicle Create(string type,
            double fuelQuantity,
            double fuelConsumption,
            double tankCapacity)
        {
            if (type == "Car")
            {
                return new Car(tankCapacity, fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                return new Truck(tankCapacity, fuelQuantity, fuelConsumption);
            }
            else if (type == "Bus")
            {
                return new Bus(tankCapacity, fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new ArgumentException("Type doesn't exits!");
            }
        }
    }
}
