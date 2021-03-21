using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";

            Dictionary<string, string> contestsInfo = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> studentsInfo = new Dictionary<string, Dictionary<string, int>>();

            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] data = command
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                string contest = data[0];
                string passwordForContest = data[1];
                contestsInfo.Add(contest, passwordForContest);
            }

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] data = command
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = data[0];
                string password = data[1];
                string username = data[2];
                int points = int.Parse(data[3]);

                if (contestsInfo.ContainsKey(contest))
                {
                    if (contestsInfo[contest] == password)
                    {
                        if (!studentsInfo.ContainsKey(username))
                        {
                            studentsInfo[username] = new Dictionary<string, int>();
                            studentsInfo[username][contest] = points;
                        }
                        else
                        {
                            if (!studentsInfo[username].ContainsKey(contest))
                            {
                                studentsInfo[username][contest] = points;
                            }
                            else
                            {
                                if (points > studentsInfo[username][contest])
                                {
                                    studentsInfo[username][contest] = points;
                                }
                            }
                        }
                    }
                }
            }

            int maxSum = 0;
            string nameOFTheBest = "";

            foreach (var name in studentsInfo)
            {
                int sum = 0;
                foreach (var contest in studentsInfo[name.Key])
                {
                    sum += contest.Value;
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    nameOFTheBest = name.Key;
                } 
            }

            Console.WriteLine($"Best candidate is {nameOFTheBest} with total {maxSum} points.");

            var sortedDict = studentsInfo
                .OrderBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);
            Console.WriteLine("Ranking:");
            foreach (var name in sortedDict)
            {
                Console.WriteLine(name.Key);

                foreach (var contest in sortedDict[name.Key].OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
