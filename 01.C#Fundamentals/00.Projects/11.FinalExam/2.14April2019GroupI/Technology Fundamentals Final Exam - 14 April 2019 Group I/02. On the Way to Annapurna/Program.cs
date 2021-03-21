using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> stores = new Dictionary<string, List<string>>();

            string command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                string action = data[0];
                string store = data[1];

                if (!stores.ContainsKey(store))
                {
                    stores[store] = new List<string>();
                }

                if (action == "Add")
                {
                    List<string> items = data[2]
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    foreach (var item in items)
                    {
                        stores[store].Add(item);
                    }
                }
                else if (action == "Remove")
                {
                    stores.Remove(store);
                }
            }

            var sorted = stores
                .OrderByDescending(a => a.Value.Count)
                .ThenByDescending(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine("Stores list:");
            foreach (var store in sorted)
            {
                Console.WriteLine(store.Key);

                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
