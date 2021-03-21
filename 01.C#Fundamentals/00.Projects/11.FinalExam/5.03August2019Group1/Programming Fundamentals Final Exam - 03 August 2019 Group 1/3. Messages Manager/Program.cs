using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            Dictionary<string, int> messanges = new Dictionary<string, int>();
            Dictionary<string, int> receivedmessanges = new Dictionary<string, int>();

            string command = "";
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] data = command.Split("=", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];

                if (action == "Add")
                {
                    string username = data[1];

                    int sent = int.Parse(data[2]);
                    int received = int.Parse(data[3]);

                    if (!messanges.ContainsKey(username))
                    {
                        messanges[username] = sent;
                        receivedmessanges[username] = received;
                    }
                   
                }
                else if (action == "Message")
                {
                    string sender = data[1];
                    string receiver = data[2];

                    if (messanges.ContainsKey(sender) && messanges.ContainsKey(receiver))
                    {
                        messanges[sender]++;
                        if (messanges[sender] + receivedmessanges[sender] >= capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            messanges.Remove(sender);
                            receivedmessanges.Remove(sender);
                        }

                        receivedmessanges[receiver]++;

                        if (messanges[receiver] + receivedmessanges[receiver] >= capacity)
                        {
                            Console.WriteLine($"{receiver} reached the capacity!");
                            messanges.Remove(receiver);
                            receivedmessanges.Remove(receiver);
                        }
                    }
                }
                else if (action == "Empty")
                {
                    string username = data[1];

                    if (username == "All")
                    {
                        foreach (var name in messanges.Keys)
                        {
                            messanges.Remove(name);
                            receivedmessanges.Remove(name);
                        }
                    }
                    else
                    {
                        messanges.Remove(username);
                        receivedmessanges.Remove(username);
                    }
                }
            }

            Console.WriteLine($"Users count: {messanges.Keys.Count()}");

            var sorted = receivedmessanges
                .OrderByDescending(a => a.Value)
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var name in sorted)
            {
                Console.WriteLine($"{name.Key} - {name.Value + messanges[name.Key]}");
            }
        }
    }
}
