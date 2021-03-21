using System;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            double health = 100;
            double bitcoins = 0;

            string[] arr = Console
                .ReadLine()
                .Split("|");

            for (int i = 0; i < arr.Length; i++)
            {
                string[] allCommand = arr[i].Split();
                string action = allCommand[0];
                int number = int.Parse(allCommand[1]);
                if (action == "potion")
                {
                    if (health + number > 100)
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                    }
                    else 
                    {
                        Console.WriteLine($"You healed for {number} hp.");
                        health += number;
                    }

                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (action == "chest")
                {
                    Console.WriteLine($"You found {number} bitcoins.");
                    bitcoins += number;
                }
                else
                {
                    health -= number;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {action}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {action}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                }
               
            }

            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
