namespace P01.Vehicle.Models
{
    using System;
    public class Truck : Vehicle
    {
        private const double AIR_CONDITIONERS_CONSUMPTION = 1.6;
        private const double REFUEL_CAPACITY = 0.95;

        public Truck(int tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption
            => base.FuelConsumption + AIR_CONDITIONERS_CONSUMPTION;

        public override void Refuel(double amountOfFuel)
        {
            if (this.TankCapacity < amountOfFuel)
            {
                throw new ArgumentException($"Cannot fit {amountOfFuel} fuel in the tank");
            }

            base.Refuel(amountOfFuel * REFUEL_CAPACITY);
        }
    }
}
