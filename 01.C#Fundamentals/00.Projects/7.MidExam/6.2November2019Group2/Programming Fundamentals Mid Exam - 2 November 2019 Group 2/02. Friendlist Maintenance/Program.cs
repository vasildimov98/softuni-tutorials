using System;

namespace _02._Friendlist_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] friends = Console
               .ReadLine()
               .Split(", ");

            string command = "";

            while ((command = Console.ReadLine()) != "Report")
            {
                string[] allCommands = command.Split();

                string action = allCommands[0];

                if (action == "Blacklist")
                {
                    BlacklistedFriend(friends, allCommands);
                }
                else if (action == "Error")
                {
                    LostFriend(friends, allCommands);
                }
                else if (action == "Change")
                {
                    ChangeName(friends, allCommands);
                }
            }

            int blacklistedNum, lostNum;
            GetCount(friends, out blacklistedNum, out lostNum);

            Console.WriteLine($"Blacklisted names: {blacklistedNum}");
            Console.WriteLine($"Lost names: {lostNum}");
            Console.WriteLine(string.Join(" ", friends));
        }

        private static void GetCount(string[] friends, out int blacklistedNum, out int lostNum)
        {
            blacklistedNum = 0;
            lostNum = 0;
            for (int i = 0; i < friends.Length; i++)
            {
                if (friends[i] == "Blacklisted")
                {
                    blacklistedNum++;
                }

                if (friends[i] == "Lost")
                {
                    lostNum++;
                }
            }
        }

        private static void ChangeName(string[] friends, string[] allCommands)
        {
            int index = int.Parse(allCommands[1]);
            string newName = allCommands[2];

            if (index >= 0 && index < friends.Length)
            {
                string currentName = friends[index];
                friends[index] = newName;

                Console.WriteLine($"{currentName} changed his username to {newName}.");
            }
        }

        private static void LostFriend(string[] friends, string[] allCommands)
        {
            int index = int.Parse(allCommands[1]);
            string name = friends[index];
            if (name != "Blacklisted" && name != "Lost")
            {
                friends[index] = "Lost";
                Console.WriteLine($"{name} was lost due to an error.");
            }
        }

        private static void BlacklistedFriend(string[] friends, string[] allCommands)
        {
            string name = allCommands[1];
            bool isNotFound = true;
            for (int i = 0; i < friends.Length; i++)
            {
                if (friends[i] == name)
                {
                    friends[i] = "Blacklisted";
                    Console.WriteLine($"{name} was blacklisted.");
                    isNotFound = false;
                    break;
                }
            }

            if (isNotFound)
            {
                Console.WriteLine($"{name} was not found.");
            }
        }
    }
}
