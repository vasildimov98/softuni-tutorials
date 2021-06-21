namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumption;
            }
        }
        public double Fuel { get; set; }

        public int HorsePower { get; }

        public virtual void Drive(double kilometers)
        {
            var travelledKilometers = kilometers * this.FuelConsumption;

            this.Fuel -= travelledKilometers;
        }
    }
}
