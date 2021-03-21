using P01.Vehicles.Exeptions;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace P01.Vehicles.Modules
{
    public class Car : Vehicle
    {
        private const double CAR_CONSUMPTION_INCREASE = 0.9;
        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption
            => base.FuelConsumption + CAR_CONSUMPTION_INCREASE;
    }
}
