namespace P07.TheV_Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<string, Dictionary<string, SortedSet<string>>> myVLogger;

        private const string VLOGGER_FOLLOWING = "following";
        private const string VLOGGER_FOLLOWERS = "followers";
        public static void Main()
        {
            myVLogger = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            GetAllVloggers();

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"The V-Logger has a total of {myVLogger.Count} vloggers in its logs.");

            var myOrderedVLogger = myVLogger
                .OrderByDescending(vl => vl.Value[VLOGGER_FOLLOWERS].Count)
                .ThenBy(vl => vl.Value[VLOGGER_FOLLOWING].Count)
                .ToDictionary(k => k.Key, v => v.Value);

            var mostFamountVlogger = myOrderedVLogger
                .First();

            PrintTheMostFamousOne(mostFamountVlogger);

            PrintTheRestOfTheVloggers(myOrderedVLogger);
        }

        private static void PrintTheRestOfTheVloggers(Dictionary<string, Dictionary<string, SortedSet<string>>> myOrderedVLogger)
        {
            var count = 2;
            foreach (var (vlogger, vloggerInfo) in myOrderedVLogger.Skip(1))
            {
                var countOfVloggerFollowers = vloggerInfo[VLOGGER_FOLLOWERS].Count;
                var countOfVloggerFollowing = vloggerInfo[VLOGGER_FOLLOWING].Count;
                Console.WriteLine($"{count++}. {vlogger} : {countOfVloggerFollowers} followers, {countOfVloggerFollowing} following");
            }
        }

        private static void PrintTheMostFamousOne(KeyValuePair<string, Dictionary<string, SortedSet<string>>> mostFamountVlogger)
        {
            var count = 1;
            var countOfMostFamousVloggerFollowers = mostFamountVlogger.Value[VLOGGER_FOLLOWERS].Count;
            var countOfMostFamousVloggerFollowing = mostFamountVlogger.Value[VLOGGER_FOLLOWING].Count;
            Console.WriteLine($"{count++}. {mostFamountVlogger.Key} : {countOfMostFamousVloggerFollowers} followers, {countOfMostFamousVloggerFollowing} following");

            foreach (var follower in mostFamountVlogger.Value[VLOGGER_FOLLOWERS])
            {
                Console.WriteLine($"*  {follower}");
            }
        }

        private static void GetAllVloggers()
        {
            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                var cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var firstVlogger = cmdArgs[0];
                var action = cmdArgs[1];

                ProceedCommand(cmdArgs, firstVlogger, action);
            }
        }

        private static void ProceedCommand(string[] cmdArgs, string firstVlogger, string action)
        {
            if (action == "joined")
            {
                JoinVlogger(firstVlogger);
            }
            else
            {
                var secondVlogger = cmdArgs[2];
                GetVloggerFolling(VLOGGER_FOLLOWING,
                    VLOGGER_FOLLOWERS,
                    firstVlogger,
                    secondVlogger);
            }
        }

        private static void JoinVlogger(string firstVlogger)
        {
            if (!myVLogger.ContainsKey(firstVlogger))
            {
                myVLogger[firstVlogger] = new Dictionary<string, SortedSet<string>>();
                myVLogger[firstVlogger][VLOGGER_FOLLOWING] = new SortedSet<string>();
                myVLogger[firstVlogger][VLOGGER_FOLLOWERS] = new SortedSet<string>();
            }
        }

        private static void GetVloggerFolling(string VLOGGER_FOLLOWING,
            string VLOGGER_FOLLOWERS,
            string firstVlogger,
            string secondVlogger)
        {
            if (firstVlogger != secondVlogger
                                    && myVLogger.ContainsKey(firstVlogger)
                                    && myVLogger.ContainsKey(secondVlogger))
            {
                myVLogger[firstVlogger][VLOGGER_FOLLOWING].Add(secondVlogger);
                myVLogger[secondVlogger][VLOGGER_FOLLOWERS].Add(firstVlogger);
            }
        }
    }
}
