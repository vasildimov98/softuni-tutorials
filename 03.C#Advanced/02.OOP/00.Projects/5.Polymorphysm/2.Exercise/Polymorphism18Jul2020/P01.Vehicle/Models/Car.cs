namespace P01.Vehicle.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITIONERS_CONSUMPTION = 0.9;

        public Car(int tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption
            => base.FuelConsumption + AIR_CONDITIONERS_CONSUMPTION;
    }
}
