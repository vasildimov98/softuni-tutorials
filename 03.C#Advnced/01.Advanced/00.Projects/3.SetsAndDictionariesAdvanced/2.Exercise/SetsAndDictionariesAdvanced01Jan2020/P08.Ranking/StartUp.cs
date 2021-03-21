namespace P08.Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<string, string> contestsInfo;
        private static SortedDictionary<string, Dictionary<string, int>> contestersInfo;
        public static void Main()
        {
            contestsInfo = new Dictionary<string, string>();
            contestersInfo = new SortedDictionary<string, Dictionary<string, int>>();

            GetAllContestsInfo();

            GetAllContesters();

            PrintResult();
        }

        private static void PrintResult()
        {
            PrintBestCandidate();
            Console.WriteLine("Ranking:");
            PrintContestersInfo();
        }

        private static void PrintContestersInfo()
        {
            foreach (var (contesterName, contestsInfo) in contestersInfo)
            {
                Console.WriteLine(contesterName);

                foreach (var (contest, points) in contestsInfo
                    .OrderByDescending(ct => ct.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }

        private static void GetAllContesters()
        {
            string command;
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                var cmdArgs = command
                   .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                var contest = cmdArgs[0];
                var password = cmdArgs[1];
                var username = cmdArgs[2];
                var points = int.Parse(cmdArgs[3]);

                if (!ValidateContest(contest, password))
                {
                    continue;
                }

                UpdateContesterInfo(contest,
                    username,
                    points);
            }
        }

        private static void PrintBestCandidate()
        {
            var bestCandidate = contestersInfo
                            .OrderByDescending(ct => ct.Value.Values.Sum())
                            .FirstOrDefault();

            var bestCandidateName = bestCandidate.Key;
            var bestCandidatePoints = bestCandidate.Value.Values.Sum();
            Console.WriteLine($"Best candidate is {bestCandidateName} with total {bestCandidatePoints} points.");
        }

        private static void UpdateContesterInfo(string contest, 
            string username,
            int points)
        {
            if (!contestersInfo.ContainsKey(username))
            {
                contestersInfo[username] = new Dictionary<string, int>();
            }

            if (!contestersInfo[username].ContainsKey(contest))
            {
                contestersInfo[username][contest] = points;
            }
            else if (contestersInfo[username][contest] < points)
            {
                contestersInfo[username][contest] = points;
            }
        }

        private static bool ValidateContest(string contest, string password)
        {
            return contestsInfo.ContainsKey(contest)
                && contestsInfo[contest] == password;
        }

        private static void GetAllContestsInfo()
        {
            string command;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                var cmdArgs = command
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var contest = cmdArgs[0];
                var contestPassword = cmdArgs[1];

                if (!contestsInfo.ContainsKey(contest))
                {
                    contestsInfo[contest] = contestPassword;
                }
            }
        }
    }
}
