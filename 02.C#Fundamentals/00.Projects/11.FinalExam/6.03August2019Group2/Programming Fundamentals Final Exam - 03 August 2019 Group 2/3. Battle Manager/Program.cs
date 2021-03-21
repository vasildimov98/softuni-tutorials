using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            Dictionary<string, int> peoplesHealth = new Dictionary<string, int>();
            Dictionary<string, int> peoplesEnergy = new Dictionary<string, int>();
            while ((input = Console.ReadLine()) != "Results")
            {
                string[] data = input.Split(":", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];

                if (action == "Add")
                {
                    string personName = data[1];
                    int health = int.Parse(data[2]);
                    int energy = int.Parse(data[3]);

                    if (!peoplesHealth.ContainsKey(personName))
                    {
                        peoplesHealth[personName] = 0;
                        peoplesEnergy[personName] = energy;
                    }

                    peoplesHealth[personName] += health;
                }
                else if (action == "Attack")
                {
                    string attackerName = data[1];
                    string defenderName = data[2];
                    int damage = int.Parse(data[3]);

                    if (peoplesHealth.ContainsKey(attackerName) && peoplesHealth.ContainsKey(defenderName))
                    {
                        peoplesHealth[defenderName] -= damage;

                        if (peoplesHealth[defenderName] <= 0)
                        {
                            peoplesHealth.Remove(defenderName);
                            peoplesEnergy.Remove(defenderName);

                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        peoplesEnergy[attackerName]--;

                        if (peoplesEnergy[attackerName] <= 0)
                        {
                            peoplesHealth.Remove(attackerName);
                            peoplesEnergy.Remove(attackerName);

                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }
                else if (action == "Delete")
                {
                    string username = data[1];
                    if (username == "All")
                    {
                        foreach (var name in peoplesHealth)
                        {
                            peoplesHealth.Remove(name.Key);
                            peoplesEnergy.Remove(name.Key);
                        }
                    }
                    else
                    {
                        peoplesHealth.Remove(username);
                        peoplesEnergy.Remove(username);
                    }
                }
            }

            Console.WriteLine($"People count: {peoplesHealth.Keys.Count()}");

            var sorted = peoplesHealth
                .OrderByDescending(p => p.Value)
                .ThenBy(n => n.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var person in sorted)
            {
                Console.WriteLine($"{person.Key} - {person.Value} - {peoplesEnergy[person.Key]}");
            }
        }
    }
}
