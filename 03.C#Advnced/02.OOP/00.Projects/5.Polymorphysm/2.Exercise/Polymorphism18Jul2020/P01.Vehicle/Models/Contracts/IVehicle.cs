namespace P01.Vehicle.Models.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        int TankCapacity { get; }

        string Drive(double distance);
        void Refuel(double amountOfFuel);
    }
}
