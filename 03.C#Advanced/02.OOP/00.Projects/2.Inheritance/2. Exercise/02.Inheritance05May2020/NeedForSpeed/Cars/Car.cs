using System.ComponentModel;

namespace NeedForSpeed.Cars
{
    public class Car : Vehicle
    {
        private const int DefaultFuelConsumption = 3;

        public Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption => DefaultFuelConsumption;

        public override void Drive(double kilometers)
        {
            var travelledKilometers = kilometers * FuelConsumption;

            if (Fuel - travelledKilometers >= 0)
            {
                Fuel -= travelledKilometers;
            }
        }
    }
}
