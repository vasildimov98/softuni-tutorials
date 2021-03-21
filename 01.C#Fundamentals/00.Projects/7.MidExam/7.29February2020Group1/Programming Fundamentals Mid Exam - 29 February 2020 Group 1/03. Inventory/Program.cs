using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console
                .ReadLine()
                .Split(", ")
                .ToList();

            string command = "";

            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] allCommand = command.Split(" - ");

                string action = allCommand[0];

                if (action == "Collect")
                {
                    string item = allCommand[1];
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (action == "Drop")
                {
                    string item = allCommand[1];
                    if (items.Contains(item))
                    {
                        items.Remove(item);    
                    }
                }
                else if (action == "Combine Items")
                {
                    string[] allItems = allCommand[1].Split(":");
                    string oldItem = allItems[0];
                    string newItem = allItems[1];
                    if (items.Contains(oldItem))
                    {
                        int index = items.IndexOf(oldItem);
                        items.Insert(index + 1, newItem);
                    }
                }
                else if (action == "Renew")
                {
                    string item = allCommand[1];
                    if (items.Contains(item))
                    {
                        int index = items.IndexOf(item);
                        items.RemoveAt(index);
                        items.Add(item);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
