﻿namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DefaultFuelConsumption = 10;

        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption
            => DefaultFuelConsumption;

        public override void Drive(double kilometers)
        {
            var fuelNeeded = this.FuelConsumption * kilometers;

            base.Fuel -= fuelNeeded;
        }
    }
}
