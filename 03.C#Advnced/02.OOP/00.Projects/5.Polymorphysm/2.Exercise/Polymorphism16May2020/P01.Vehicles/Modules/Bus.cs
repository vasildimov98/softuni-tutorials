namespace P01.Vehicles.Modules
{
    using System;

    using P01.Vehicles.Exeptions;
    public class Bus : Vehicle
    {
        private const double BUS_CONSUMPTION_INCREASE = 1.4;
        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {

        }

        public override string Drive(double distance)
        {
            var fuelNeeded =
                    (base.FuelConsumption + BUS_CONSUMPTION_INCREASE) * distance;
            
            if (fuelNeeded > this.FuelQuantity)
            {
                var msg = string
                    .Format(InvalidTravelExeption
                    .NotEnoughtFuelExeption, this.GetType().Name);
                throw new InvalidOperationException(msg);
            }

            base.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}
