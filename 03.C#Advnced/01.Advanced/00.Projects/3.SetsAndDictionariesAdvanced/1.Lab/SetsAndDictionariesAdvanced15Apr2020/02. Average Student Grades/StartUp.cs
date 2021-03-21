using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class StartUp
    {
        static void Main(string[] args)
        {
            /*
                7
                Ivancho 5.20
                Mariika 5.50
                Ivancho 3.20
                Mariika 2.50
                Stamat 2.00
                Mariika 3.46
                Stamat 3.00
             */

            var n = int.Parse(Console.ReadLine());

            var dict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                var data = Console
                    .ReadLine()
                    .Split();

                var name = data[0]; 
                var grade = decimal.Parse(data[1]);

                if (!dict.ContainsKey(name))
                {
                    dict[name] = new List<decimal>();
                }

                dict[name].Add(grade);
            }

            foreach (var (name, grades) in dict)
            {
                var allGrades = string.Join(" ", grades.Select(a => a.ToString("F2")));
                var avg = grades.Average();

                Console.WriteLine($"{name} -> {allGrades} (avg: {avg:F2})");
            }
        }
    }
}
