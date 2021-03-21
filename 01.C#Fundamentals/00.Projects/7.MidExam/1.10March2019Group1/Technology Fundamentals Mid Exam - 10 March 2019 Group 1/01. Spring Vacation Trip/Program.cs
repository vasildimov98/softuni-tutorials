using System;

namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTrip = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int groupOfPeople = int.Parse(Console.ReadLine());

            double fuelPricePerKm = double.Parse(Console.ReadLine());
            double foodExpensesPerPerson = double.Parse(Console.ReadLine());
            double roomPricePerRoom = double.Parse(Console.ReadLine());

            double foodExpenses = foodExpensesPerPerson * groupOfPeople * daysOfTrip;
            double hotelExpenses = roomPricePerRoom * groupOfPeople * daysOfTrip;

            if (groupOfPeople > 10)
            {
                hotelExpenses = hotelExpenses * 0.75;
            }

            double currExpenses = foodExpenses + hotelExpenses;
            double fuelCost = 0;
            double diff = 0;
            for (int i = 1; i <= daysOfTrip; i++)
            {
                double travelledDistance = double.Parse(Console.ReadLine());
                fuelCost = travelledDistance * fuelPricePerKm;
                currExpenses += fuelCost;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    currExpenses = currExpenses * 1.4;
                }
                else if (i % 7 == 0)
                {
                    currExpenses -= currExpenses / groupOfPeople;
                }

                if (currExpenses > budget)
                {
                    diff = currExpenses - budget;
                    Console.WriteLine($"Not enough money to continue the trip. You need {diff:f2}$ more.");
                    return;
                }
            }

            diff = budget - currExpenses;
            Console.WriteLine($"You have reached the destination. You have {diff:F2}$ budget left.");
        }
    }
}
