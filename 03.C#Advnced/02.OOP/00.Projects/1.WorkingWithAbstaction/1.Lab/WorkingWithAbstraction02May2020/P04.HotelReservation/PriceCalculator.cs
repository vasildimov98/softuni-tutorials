namespace P04.HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(
            decimal pricePerDay,
            int numberOfDays,
            Season season,
            Discount discount = Discount.None)
        {
            var finalPrice = pricePerDay * (int)season * numberOfDays;

            finalPrice *= (100 - (decimal)discount) / 100;

            return finalPrice;
        }
    }
}
