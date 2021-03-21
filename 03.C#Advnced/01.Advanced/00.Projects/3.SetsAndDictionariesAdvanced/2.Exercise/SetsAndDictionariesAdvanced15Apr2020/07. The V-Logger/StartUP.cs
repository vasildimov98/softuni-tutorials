using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class StartUp
    {
        static void Main()
        {
            var followers = new Dictionary<string, SortedSet<string>>();
            var followed = new Dictionary<string, SortedSet<string>>();
            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                var data = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var vlogerName = data[0];
                var action = data[1];

                if (action == "joined" && (!followers.ContainsKey(vlogerName)))
                {
                    followers[vlogerName] = new SortedSet<string>();
                    followed[vlogerName] = new SortedSet<string>();
                }
                else if (action == "followed")
                {
                    var followedVlogger = data[2];

                    if (!followers.ContainsKey(vlogerName)
                        || !followers.ContainsKey(followedVlogger)
                        || vlogerName == followedVlogger)
                    {
                        continue;
                    }

                    followed[vlogerName].Add(followedVlogger);
                    followers[followedVlogger].Add(vlogerName);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {followers.Count} vloggers in its logs.");

            var orderedFollowers = followers
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => followed[kvp.Key].Count)
                .ToDictionary(k => k.Key, v => v.Value);

            var count = 1;
            var mostFamousVlogger = orderedFollowers.First();
            Console.WriteLine($"{count++}. {mostFamousVlogger.Key} : {mostFamousVlogger.Value.Count} followers, {followed[mostFamousVlogger.Key].Count} following");

            foreach (var fol in mostFamousVlogger.Value)
            {
                Console.WriteLine($"*  {fol}");
            }

            foreach (var fol in orderedFollowers.Skip(1))
            {
                Console.WriteLine($"{count++}. {fol.Key} : {fol.Value.Count} followers, {followed[fol.Key].Count} following");
            }
        }
    }
}
