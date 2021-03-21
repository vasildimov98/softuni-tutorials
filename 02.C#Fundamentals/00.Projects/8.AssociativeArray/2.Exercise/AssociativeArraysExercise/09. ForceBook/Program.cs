using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        private static object stringSplitOption;

        static void Main(string[] args)
        {
            string command = "";

            Dictionary<string, List<string>> force = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] data = command
                   .Split(new[] { " | ", " -> " },
                   StringSplitOptions
                   .RemoveEmptyEntries);

                string forceSide = "";
                string forceUser = "";
                if (command.Contains("|"))
                {
                    forceSide = data[0];
                    forceUser = data[1];
                    AddForceUser(force, forceSide, forceUser);

                }
                else if (command.Contains("->"))
                {
                    forceUser = data[0];
                    forceSide = data[1];
                    foreach (var kvp in force)
                    {
                        if (kvp.Value.Contains(forceUser))
                        {
                            force[kvp.Key].Remove(forceUser);
                        }
                    }

                    if (!force.ContainsKey(forceSide))
                    {
                        force.Add(forceSide, new List<string>());
                    }

                    force[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }

            var sortedForces = force
                .Where(a => a.Value.Count > 0)
                .OrderByDescending(a => a.Value.Count)
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in sortedForces)
            {
                string side = kvp.Key;
                List<string> sortedNames = kvp.Value
                    .OrderBy(a => a)
                    .ToList();

                Console.WriteLine($"Side: {side}, Members: {sortedNames.Count}");
                foreach (var name in sortedNames)
                {
                    Console.WriteLine($"! {name}");
                }
            }
        }

        private static void AddForceUser(Dictionary<string, List<string>> force, string forceSide, string forceUser)
        {
            if (!force.ContainsKey(forceSide))
            {
                force.Add(forceSide, new List<string>());
            }

            if (!force.Values.Any(l => l.Contains(forceUser)))
            {
                force[forceSide].Add(forceUser);
            }
        }
    }
}
