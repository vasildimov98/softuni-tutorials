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
            => DefaultFuelConsumption;
        public int HorsePower { get; private set; }
        public double Fuel { get; protected set; }

        public virtual void Drive(double kilometers)
        {
            var neededFuel = this.FuelConsumption * kilometers;

            this.Fuel -= neededFuel;
        }
    }
}
