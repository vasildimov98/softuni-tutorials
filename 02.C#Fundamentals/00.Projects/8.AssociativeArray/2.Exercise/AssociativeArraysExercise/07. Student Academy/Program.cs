using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double>());
                }
                dict[name].Add(grade);
            }

            foreach (var item in dict)
            {
                if (item.Value.Average() < 4.50)
                {
                    dict.Remove(item.Key);
                }
                else
                {
                    double averageGrade = item.Value.Average();
                    item.Value.RemoveRange(0, item.Value.Count);
                    item.Value.Add(averageGrade);
                }
            }

            foreach (var item in dict.OrderByDescending(a => a.Value[0]))
            {
                Console.WriteLine($"{item.Key} -> {item.Value[0]:F2}");
            }
        }
    }
}
