using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            var contestInfo = new Dictionary<string, string>();
            var usernameInfo = new Dictionary<string, Dictionary<string, int>>();

            while ((command = Console.ReadLine()) != "end of contests")
            {
                var data = command
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var contest = data[0];
                var passwordForContest = data[1];

                if (!contestInfo.ContainsKey(contest))
                {
                    contestInfo[contest] = passwordForContest;
                }
            }

            while ((command = Console.ReadLine()) != "end of submissions")
            {
                var data = command
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var contest = data[0];
                var password = data[1];
                var username = data[2];
                var points = int.Parse(data[3]);

                if (contestInfo.ContainsKey(contest) && contestInfo[contest] == password)
                {
                    if (!usernameInfo.ContainsKey(username))
                    {
                        usernameInfo[username] = new Dictionary<string, int>();
                    }

                    if (!usernameInfo[username].ContainsKey(contest))
                    {
                        usernameInfo[username][contest] = 0;
                    }

                    if (points > usernameInfo[username][contest])
                    {
                        usernameInfo[username][contest] = points;
                    }
                }
            }

            var firstStudent = usernameInfo
                .OrderByDescending(kvp => kvp.Value.Values.Max())
                .First();

            Console.WriteLine($"Best candidate is {firstStudent.Key} with total {firstStudent.Value.Values.Sum()} points.");

            Console.WriteLine("Ranking:");
            foreach (var (username, contests) in usernameInfo
                .OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine(username);
                foreach (var (contest, points) in contests
                    .OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}
