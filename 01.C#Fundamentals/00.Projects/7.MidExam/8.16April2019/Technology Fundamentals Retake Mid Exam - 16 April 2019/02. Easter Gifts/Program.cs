using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gifts = Console
                 .ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command;

            while ((command = Console.ReadLine()) != "No Money")
            {
                string[] data = command.Split();

                string action = data[0];

                if (action == "OutOfStock")
                {
                    string gift = data[1];

                    if (gifts.Contains(gift))
                    {
                        for (int i = 0; i < gifts.Length; i++)
                        {
                            if (gifts[i] == gift)
                            {
                                gifts[i] = "None";
                            }
                        }
                    }
                }
                else if (action == "Required")
                {
                    string gift = data[1];
                    int index = int.Parse(data[2]);

                    if (index >= 0 && index < gifts.Length)
                    {
                        gifts[index] = gift;
                    }
                }
                else if (action == "JustInCase")
                {
                    gifts[gifts.Length - 1] = data[1];
                }
            }

            foreach (var gift in gifts)
            {
                if (gift != "None")
                {
                    Console.Write($"{gift} ");
                }
            }
        }
    }
}
