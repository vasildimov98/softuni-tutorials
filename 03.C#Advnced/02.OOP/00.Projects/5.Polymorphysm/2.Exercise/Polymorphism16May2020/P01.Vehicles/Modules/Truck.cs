namespace P01.Vehicles.Modules
{
    using System;

    using P01.Vehicles.Exeptions;

    public class Truck : Vehicle
    {
        private const double TRUCK_CONSUMPTION_INCREASE = 1.6;
        private const double TRUCK_TANK_PERCENTEGE_CAPACITY = 0.95;

        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption
            => base.FuelConsumption + TRUCK_CONSUMPTION_INCREASE;

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                var msg = InvalidTravelExeption.NegativeNumberExexption;
                throw new InvalidOperationException(msg);
            }

            if (fuel > this.TankCapacity)
            {
                var msg = string
                        .Format(InvalidTravelExeption
                        .OutOfRangeTankCapacity, fuel);

                throw new InvalidOperationException(msg);
            }

            this.FuelQuantity += fuel*TRUCK_TANK_PERCENTEGE_CAPACITY;
        }
    }
}
