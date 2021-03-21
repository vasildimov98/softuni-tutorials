namespace P01.Vehicles.Exeptions
{
    public static class InvalidTravelExeption
    {
        public static string NotEnoughtFuelExeption
            => "{0} needs refueling";

        public static string OutOfRangeTankCapacity
            => "Cannot fit {0} fuel in the tank";

        public static string NegativeNumberExexption
            => "Fuel must be a positive number";
    }
}
