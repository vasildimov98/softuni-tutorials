using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> results = new Dictionary<string, int>();

            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string command = "";

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] data = command
                    .Split("-");

                string username = data[0];
                string action = data[1];

                if (!(action == "banned"))
                {
                    string language = data[1];
                    int points = int.Parse(data[2]);

                    if (!results.ContainsKey(username))
                    {
                        results[username] = points;
                    }
                    else
                    {
                        if (points > results[username])
                        {
                            results[username] = points;
                        }
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions[language] = 1;
                    }
                    else
                    {
                        submissions[language]++;
                    }
                }
                else
                {
                    if (results.ContainsKey(username))
                    {
                        results.Remove(username);
                    }
                }
            }

            var sortedResult = results
                .OrderByDescending(a => a.Value)
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine("Results:");
            foreach (var kvp in sortedResult)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            var sortedSubmmision = submissions
                .OrderByDescending(a => a.Value)
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine("Submissions:");
            foreach (var kvp in sortedSubmmision)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
