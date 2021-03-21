using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Froggy_Squad
{
    class Program
    {
        static void Main()
        {
            List<string> frogs = Console
                .ReadLine()
                .Split()
                .ToList();

            while (true)
            {
                string[] allCommands = Console
                    .ReadLine()
                    .Split();

                string action = allCommands[0];

                if (action == "Join")
                {
                    AddFrog(frogs, allCommands);
                }
                else if (action == "Jump")
                {
                    InsertFrog(frogs, allCommands);
                }
                else if (action == "Dive")
                {
                    RemoveFrog(frogs, allCommands);
                }
                else if (action == "First" || action == "Last")
                {
                    GetFirstOrLast(frogs, allCommands, action);
                }
                else if (action == "Print")
                {
                    Print(frogs, allCommands);
                    return;
                }

            }
        }

        private static void Print(List<string> frogs, string[] allCommands)
        {
            if (allCommands[1] == "Reversed")
            {
                frogs.Reverse();
            }

            Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
        }

        private static void GetFirstOrLast(List<string> frogs, string[] allCommands, string action)
        {
            int count = int.Parse(allCommands[1]);
            string result = "";
            if (action == "First")
            {
                int endIndex = 0 + count;
                if (endIndex > frogs.Count)
                {
                    endIndex = frogs.Count;
                }

                for (int i = 0; i < endIndex; i++)
                {
                    result += $"{frogs[i]} ";
                }
            }
            else if (action == "Last")
            {
                int startIndex = frogs.Count - count;

                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                for (int i = startIndex; i < frogs.Count; i++)
                {
                    result += $"{frogs[i]} ";
                }
            }

            Console.WriteLine(result.Trim());
        }

        private static void RemoveFrog(List<string> frogs, string[] allCommands)
        {
            int index = int.Parse(allCommands[1]);

            if (index >= 0 && index < frogs.Count)
            {
                frogs.RemoveAt(index);
            }
        }

        private static void InsertFrog(List<string> frogs, string[] allCommands)
        {
            string frogName = allCommands[1];
            int index = int.Parse(allCommands[2]);

            if (index >= 0 && index < frogs.Count)
            {
                frogs.Insert(index, frogName);
            }
        }

        private static void AddFrog(List<string> frogs, string[] allCommands)
        {
            string frogName = allCommands[1];

            frogs.Add(frogName);
        }
    }
}
