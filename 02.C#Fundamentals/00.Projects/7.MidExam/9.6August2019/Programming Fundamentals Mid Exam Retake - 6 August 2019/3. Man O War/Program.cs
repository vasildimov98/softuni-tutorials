using System;
using System.Linq;

namespace _3._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirate = Console
                 .ReadLine()
                 .Split(">", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int[] warship = Console
                 .ReadLine()
                 .Split(">", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int healthCapacity = int.Parse(Console.ReadLine());

            double critical = healthCapacity * 0.20;

            string command;

            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] data = command.Split();

                if (data[0] == "Fire")
                {
                    int index = int.Parse(data[1]);
                    int damage = int.Parse(data[2]);

                    if (index >= 0 && index < warship.Length)
                    {
                        warship[index] -= damage;

                        if (warship[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (data[0] == "Defend")
                {
                    int startIndex = int.Parse(data[1]);
                    int endIndex = int.Parse(data[2]);

                    int damage = int.Parse(data[3]);

                    if ((startIndex >= 0 && startIndex < pirate.Length) && (endIndex >= 0 && endIndex < pirate.Length) && endIndex >= startIndex)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirate[i] -= damage;
                            if (pirate[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (data[0] == "Repair")
                {
                    int index = int.Parse(data[1]);
                    int health = int.Parse(data[2]);

                    if (index >= 0 && index < pirate.Length)
                    {
                        pirate[index] += health;

                        if (pirate[index] > healthCapacity)
                        {
                            pirate[index] = healthCapacity;
                        }
                    }
                }
                else if (data[0] == "Status")
                {
                    int count = 0;
                    for (int i = 0; i < pirate.Length; i++)
                    {
                        if (pirate[i] < critical)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine($"{count} sections need repair.");
                }
            }

            Console.WriteLine($"Pirate ship status: {pirate.Sum()}");
            Console.WriteLine($"Warship status: {warship.Sum()}");
        }
    }
}
