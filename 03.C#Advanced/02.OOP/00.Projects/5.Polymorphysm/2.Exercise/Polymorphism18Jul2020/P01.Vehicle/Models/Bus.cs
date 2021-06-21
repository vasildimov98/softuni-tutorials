namespace P01.Vehicle.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITIONERS_CONSUMPTION = 1.4;

        public Bus(int tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {

        }

        public string DriveWithPeople(double distance)
        {
            var neededFuel = distance * 
                (base.FuelConsumption + AIR_CONDITIONERS_CONSUMPTION);

            if (neededFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
    }
}
