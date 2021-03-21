using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            Dictionary<string, Dictionary<string, int>> contestTrack = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> personalStatistics = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "no more time")
            {
                string[] data = command
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string username = data[0];
                string contestName = data[1];
                int points = int.Parse(data[2]);

                if (!contestTrack.ContainsKey(contestName))
                {
                    contestTrack[contestName] = new Dictionary<string, int>();
                    contestTrack[contestName][username] = points;

                    if (!personalStatistics.ContainsKey(username))
                    {
                        personalStatistics[username] = points;
                    }
                    else
                    {
                        personalStatistics[username] += points;
                    }
                }
                else
                {
                    if (contestTrack[contestName].ContainsKey(username) && contestTrack[contestName][username] < points)
                    {
                        contestTrack[contestName][username] = points;

                        personalStatistics[username] = points;
                    }
                    else if (!contestTrack[contestName].ContainsKey(username))
                    {
                        contestTrack[contestName][username] = points;

                        if (!personalStatistics.ContainsKey(username))
                        {
                            personalStatistics[username] = points;
                        }
                        else
                        {
                            personalStatistics[username] += points;
                        }
                    }
                }
            }

            int count = 1;
            foreach (var contest in contestTrack)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                var sorted = contestTrack[contest.Key]
                    .OrderByDescending(a => a.Value)
                    .ThenBy(a => a.Key)
                    .ToDictionary(k => k.Key, v => v.Value);

                foreach (var name in sorted)
                {
                    Console.WriteLine($"{count}. {name.Key} <::> {name.Value}");
                    count++;
                }
                count = 1;
            }

            var soredStatistics = personalStatistics
                .OrderByDescending(a => a.Value)
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine("Individual standings:");
            foreach (var name in soredStatistics)
            {
                Console.WriteLine($"{count}. {name.Key} -> {name.Value}");
                count++;
            }
            count = 1;
        }
    }
}
