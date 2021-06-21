namespace P07.SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static HashSet<string> reservationList;
        private static HashSet<string> vipList;
        public static void Main()
        {
            reservationList = new HashSet<string>();
            vipList = new HashSet<string>();

            ProceedCommand();

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(vipList.Count + reservationList.Count);

            if (vipList.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipList));
            }

            if (reservationList.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, reservationList));
            }
        }

        private static void ProceedCommand()
        {
            string command;
            while ((command = Console.ReadLine()) != "PARTY")
            {
                if (!char.IsDigit(command[0]))
                {
                    reservationList.Add(command);
                }
                else
                {
                    vipList.Add(command);
                }
            }

            while ((command = Console.ReadLine()) != "END")
            {
                reservationList.Remove(command);
                vipList.Remove(command);
            }
        }
    }
}
