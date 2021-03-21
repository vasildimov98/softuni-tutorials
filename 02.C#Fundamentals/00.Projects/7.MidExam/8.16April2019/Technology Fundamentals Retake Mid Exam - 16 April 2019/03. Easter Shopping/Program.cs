using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shops = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console
                    .ReadLine()
                    .Split();

                string action = data[0];

                if (action == "Include")
                {
                    shops.Add(data[1]);
                }
                else if (action == "Visit")
                {
                    string command = data[1];
                    int numbers = int.Parse(data[2]);

                    if (!(numbers > shops.Count))
                    {
                        if (command == "first")
                        {
                            shops.RemoveRange(0, numbers);
                        }
                        else if (command == "last")
                        {
                            shops.RemoveRange(shops.Count - numbers, numbers);
                        }
                    }
                }
                else if (action == "Prefer")
                {
                    int index1 = int.Parse(data[1]);
                    int index2 = int.Parse(data[2]);
                    if ((index1 >= 0 && index1 < shops.Count) && (index2 >= 0 && index2 < shops.Count))
                    {
                        string temp = shops[index1];
                        shops[index1] = shops[index2];
                        shops[index2] = temp;
                    }
                }
                else if (action == "Place")
                {
                    int index = int.Parse(data[2]);

                    if (index >= 0 && index < shops.Count)
                    {
                        shops.Insert(index + 1, data[1]);
                    }
                }
            }

            Console.WriteLine("Shops left: ");
            Console.WriteLine(string.Join(" ", shops));
        }
    }
}
