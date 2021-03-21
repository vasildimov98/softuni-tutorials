using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tresure = Console
                .ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] data = command.Split();

                string action = data[0];

                if (action == "Loot")
                {
                    for (int i = 1; i < data.Length; i++)
                    {
                        if (!tresure.Contains(data[i]))
                        {
                            tresure.Insert(0, data[i]);
                        }
                    }
                }
                else if (action == "Drop")
                {
                    int index = int.Parse(data[1]);

                    if ((index >= 0 && index < tresure.Count))
                    {
                        tresure.Add(tresure[index]);
                        tresure.RemoveAt(index);
                    }
                }
                else if (action == "Steal")
                {
                    int count = int.Parse(data[1]);

                    if (count > tresure.Count)
                    {
                        count = tresure.Count;
                    }

                    List<string> stolen = new List<string>();
                    for (int i = 0; i < count; i++)
                    {
                        stolen.Add(tresure[tresure.Count - 1 - i]);
                    }
                    tresure.RemoveRange(tresure.Count - count, count);
                    stolen.Reverse();
                    Console.WriteLine(string.Join(", ",stolen));
                }
            }

            if (tresure.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double sum = 0;
                foreach (var loot in tresure)
                {
                    sum += loot.Length;
                }

                double average = sum / tresure.Count;

                Console.WriteLine($"Average treasure gain: {average:F2} pirate credits.");
            }
        }
    }
}
