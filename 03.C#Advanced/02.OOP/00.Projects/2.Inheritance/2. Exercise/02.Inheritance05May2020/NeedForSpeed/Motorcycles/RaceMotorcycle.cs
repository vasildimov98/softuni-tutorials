namespace NeedForSpeed.Motorcycles
{
    public class RaceMotorcycle : Motorcycle
    {
        private const int DefaultFuelConsumption = 8;

        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption { get => DefaultFuelConsumption; }

        public override void Drive(double kilometers)
        {
            var travelledKilometers = kilometers * FuelConsumption;

            if (this.Fuel - travelledKilometers >= 0)
            {
                this.Fuel -= travelledKilometers;
            }
        }
    }
}
