using System.ComponentModel;

namespace NeedForSpeed.Cars
{
    public class SportCar : Car
    {
        private const int DefaultFuelConsumption = 10;

        public SportCar(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DefaultFuelConsumption;
        public override void Drive(double kilometers)
        {
            var travelledKilometers = kilometers * FuelConsumption;

            Fuel -= travelledKilometers;
        }
    }
}
