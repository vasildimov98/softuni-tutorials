using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            Dictionary<string, List<string>> keyValuePairs = new Dictionary<string, List<string>>();
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] data = command.Split("->",StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];
                string username = data[1];

                if (action == "Add")
                {
                    if (keyValuePairs.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                    else 
                    {
                        keyValuePairs[username] = new List<string>();
                    }
                }
                else if (action == "Send")
                {
                    string email = data[2];
                    keyValuePairs[username].Add(email);
                }
                else if (action == "Delete")
                {
                    if (keyValuePairs.ContainsKey(username))
                    {
                        keyValuePairs.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
            }

            Console.WriteLine($"Users count: {keyValuePairs.Keys.Count()}");

            var sorted = keyValuePairs
                .OrderByDescending(a => a.Value.Count())
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var name in sorted)
            {
                Console.WriteLine(name.Key);

                foreach (var email in name.Value)
                {
                    Console.WriteLine($"- {email}");
                }
            }
        }
    }
}
