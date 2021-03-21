using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main()
        {
            string command = "";

            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            while ((command = Console.ReadLine()) != "end")
            {
                string[] data = command.Split(" : ");

                string courseName = data[0];
                string studentName = data[1];

                if (!dict.ContainsKey(courseName))
                {
                    dict.Add(courseName, new List<string>());
                }
                dict[courseName].Add(studentName);
            }

            
            foreach (var item in dict
                .OrderByDescending(a => a.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var name in item.Value.OrderBy(a => a))
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
