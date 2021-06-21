namespace P01.Vehicles.Modules
{
    using System;

    using P01.Vehicles.Contracts;
    using P01.Vehicles.Exeptions;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        public Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double TankCapacity { get; private set; }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    var msg = string
                        .Format(InvalidTravelExeption
                        .OutOfRangeTankCapacity, value);

                    throw new InvalidOperationException(msg);
                }

                this.fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption { get; private set; }

        public virtual string Drive(double distance)
        {
            var fuelNeeded = this.FuelConsumption * distance;

            if (fuelNeeded > this.FuelQuantity)
            {
                var msg = string
                    .Format(InvalidTravelExeption
                    .NotEnoughtFuelExeption, this.GetType().Name);
                throw new InvalidOperationException(msg);
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            var fuelNeeded = this.FuelConsumption * distance;

            if (fuelNeeded > this.FuelQuantity)
            {
                var msg = string
                    .Format(InvalidTravelExeption
                    .NotEnoughtFuelExeption, this.GetType().Name);
                throw new InvalidOperationException(msg);
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                var msg = InvalidTravelExeption.NegativeNumberExexption;
                throw new InvalidOperationException(msg);
            }

            if (fuel > this.TankCapacity)
            {
                var msg = string
                        .Format(InvalidTravelExeption
                        .OutOfRangeTankCapacity, fuel);

                throw new InvalidOperationException(msg);
            }

            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
