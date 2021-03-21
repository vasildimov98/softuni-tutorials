namespace P01.Vehicles.Contracts
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public double TankCapacity { get; }
        string Drive(double distance);

        void Refuel(double fuel);
    }
}
