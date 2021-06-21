using System;
using System.Linq;

namespace P04.HotelReservation
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var pircePerDay = decimal.Parse(input[0]);
            var numberOfDays = int.Parse(input[1]);
            var season = 0;

            switch (input[2])
            {
                case "Autumn":
                    season = (int)Season.Autumn;
                    break;
                case "Spring":
                    season = (int)Season.Spring;
                    break;
                case "Winter":
                    season = (int)Season.Winter;
                    break;
                case "Summer":
                    season = (int)Season.Summer;
                    break;
            }

            var discountType = 0;
            if (input.Length < 4)
            {
                discountType = (int)Discount.None;
            }
            else
            {
                switch (input[3])
                {
                    case "None":
                        discountType = (int)Discount.None;
                        break;
                    case "SecondVisit":
                        discountType = (int)Discount.SecondVisit;
                        break;
                    case "VIP":
                        discountType = (int)Discount.VIP;
                        break;
                }
            }

            var totalPrice = PriceCalculator.GetTotalPrice(pircePerDay,
                numberOfDays,
                (Season)season,
                (Discount)discountType);

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
