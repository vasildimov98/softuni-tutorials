namespace P06.ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static HashSet<string> parkingLot;
        public static void Main()
        {
            parkingLot = new HashSet<string>();

            ProceedCommand();

            PrintResult();
        }

        private static void PrintResult()
        {
            if (parkingLot.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, parkingLot));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }

        private static void ProceedCommand()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var args = command
                    .Split(", ")
                    .ToArray();

                var direction = args[0];
                var carNumber = args[1];

                MakeActionToParkingLot(direction, carNumber);
            }
        }

        private static void MakeActionToParkingLot(string direction, string carNumber)
        {
            if (direction == "IN")
            {
                parkingLot.Add(carNumber);
            }
            else if (direction == "OUT")
            {
                parkingLot.Remove(carNumber);
            }
        }
    }
}
