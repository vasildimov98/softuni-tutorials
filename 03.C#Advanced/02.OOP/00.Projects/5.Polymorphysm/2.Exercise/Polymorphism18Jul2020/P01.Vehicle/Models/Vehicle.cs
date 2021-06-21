namespace P01.Vehicle.Models
{
    using System;
    using System.Data;
    using P01.Vehicle.Models.Contracts;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        public Vehicle(int tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public int TankCapacity { get; }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public virtual double FuelConsumption { get; }

        public string Drive(double distance)
        {
            var neededFuel = this.FuelConsumption * distance;

            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else 
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
        public virtual void Refuel(double amountOfFuel)
        {
            if (amountOfFuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.TankCapacity < amountOfFuel)
            {
                throw new ArgumentException($"Cannot fit {amountOfFuel} fuel in the tank");
            }

            this.FuelQuantity += amountOfFuel;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {Math.Round(this.FuelQuantity, 2, MidpointRounding.AwayFromZero):F2}";
        }
    }
}
