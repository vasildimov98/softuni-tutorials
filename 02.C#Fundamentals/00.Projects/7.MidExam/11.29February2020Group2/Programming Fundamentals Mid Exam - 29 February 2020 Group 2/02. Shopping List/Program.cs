using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console
                .ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;

            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] data = command.Split();

                if (data[0] == "Urgent")
                {
                    if (!groceries.Contains(data[1]))
                    {
                        groceries.Insert(0, data[1]);
                    }
                }
                else if (data[0] == "Unnecessary")
                {
                    if (groceries.Contains(data[1]))
                    {
                        groceries.Remove(data[1]);
                    }
                }
                else if (data[0] == "Correct")
                {
                    if (groceries.Contains(data[1]))
                    {
                        groceries[groceries.IndexOf(data[1])] = data[2];
                    }
                }
                else if (data[0] == "Rearrange")
                {
                    if (groceries.Contains(data[1]))
                    {
                        groceries.Remove(data[1]);
                        groceries.Add(data[1]);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
