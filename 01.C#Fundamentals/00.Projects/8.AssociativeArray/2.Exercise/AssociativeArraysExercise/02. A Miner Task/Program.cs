using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            Dictionary<string, int> dict = new Dictionary<string, int>();
            while ((command = Console.ReadLine()) != "stop")
            {
                string resource = command;
                int quantity = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(resource))
                {
                    dict.Add(resource, quantity);
                }
                else
                {
                    dict[resource] += quantity;
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
