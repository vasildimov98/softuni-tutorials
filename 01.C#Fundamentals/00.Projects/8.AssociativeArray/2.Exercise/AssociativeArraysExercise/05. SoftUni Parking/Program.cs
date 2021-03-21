using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console
                    .ReadLine()
                    .Split();

                string action = data[0];
                string username = data[1];

                if (action == "register")
                {
                    string licensePlateNumber = data[2];

                    if (dict.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    else
                    {
                        dict.Add(username, licensePlateNumber);

                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
                else
                {
                    if (!dict.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        dict.Remove(username);

                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
