using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Dictionary<string, List<string>> bands = new Dictionary<string, List<string>>();
            Dictionary<string, long> playTime = new Dictionary<string, long>();
            while ((command = Console.ReadLine()) != "start of concert")
            {
                string[] data = command.Split("; ", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];
                string bandName = data[1];

                if (!bands.ContainsKey(bandName))
                {
                    bands[bandName] = new List<string>();
                }

                if (!playTime.ContainsKey(bandName))
                {
                    playTime[bandName] = 0;
                }

                if (action == "Add")
                {
                    string[] members = data[2].Split(", ", StringSplitOptions.RemoveEmptyEntries);

                    foreach (var member in members)
                    {
                        if (!bands[bandName].Contains(member))
                        {
                            bands[bandName].Add(member);
                        }
                    }
                }
                else if (action == "Play")
                {
                    int time = int.Parse(data[2]);

                    playTime[bandName] += time;
                }
            }

            var sorted = playTime
                .OrderByDescending(a => a.Value)
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine($"Total time: {playTime.Values.Sum()}");
            foreach (var band in sorted)
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            string finalInput = Console.ReadLine();
            Console.WriteLine(finalInput);
            foreach (var member in bands[finalInput])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
