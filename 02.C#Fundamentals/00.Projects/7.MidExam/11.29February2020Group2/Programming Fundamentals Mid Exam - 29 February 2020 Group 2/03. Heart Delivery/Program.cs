using System;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console
                .ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToArray();

            string command;
            int place = 0;
            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] data = command.Split();

                int length = int.Parse(data[1]);

                place += length;

                if (place > neighborhood.Length - 1)
                {
                    place = 0;
                }

                if (neighborhood[place] == 0)
                {
                    Console.WriteLine($"Place {place} already had Valentine's day.");
                }
                else 
                {
                    neighborhood[place] -= 2;
                    if (neighborhood[place] == 0)
                    {
                        Console.WriteLine($"Place {place} has Valentine's day.");
                    }
                }
            }

            Console.WriteLine($"Cupid's last position was {place}.");

            bool isSuccessful = true;
            int count = 0;
            foreach (var house in neighborhood)
            {
                if (house != 0)
                {
                    isSuccessful = false;
                    count++;
                }
            }

            if (isSuccessful)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {count} places.");
            }
        }
    }
}
