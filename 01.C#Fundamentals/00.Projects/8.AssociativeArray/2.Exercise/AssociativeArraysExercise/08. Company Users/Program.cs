using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main()
        {
            string command = "";

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split(" -> ");

                string company = data[0];
                string id = data[1];

                if (!dict.ContainsKey(company))
                {
                    dict.Add(company, new List<string>());
                }

                if (!dict[company].Contains(id))
                {
                    dict[company].Add(id);
                }
            }

            foreach (var item in dict.OrderBy(a => a.Key))
            {
                Console.WriteLine(item.Key);

                foreach (var id in item.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
