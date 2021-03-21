using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Practice_Sessions
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Dictionary<string, List<string>> roads = new Dictionary<string, List<string>>();
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];
                string road = data[1];

                if (!roads.ContainsKey(road))
                {
                    roads[road] = new List<string>();
                }

                if (action == "Add")
                {
                    string racer = data[2];
                    roads[road].Add(racer);
                }
                else if (action == "Move")
                {
                    string racer = data[2];
                    string nextRoad = data[3];

                    if (roads[road].Contains(racer))
                    {
                        roads[road].Remove(racer);
                        roads[nextRoad].Add(racer);
                    }
                }
                else if (action == "Close")
                {
                    roads.Remove(road);
                }
            }

            var sorted = roads
                .OrderByDescending(a => a.Value.Count)
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine("Practice sessions:");
            foreach (var road in sorted)
            {
                Console.WriteLine(road.Key);

                foreach (var racer in road.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
