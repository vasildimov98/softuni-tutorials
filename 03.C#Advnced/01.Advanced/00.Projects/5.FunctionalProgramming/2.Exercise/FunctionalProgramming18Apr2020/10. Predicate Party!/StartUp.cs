using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class StartUp
    {
        static void Main()
        {
            var quests = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                var cmdArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = cmdArg[0];
                var criteria = cmdArg[1];
                var filter = cmdArg[2];

                var predicate = GetPredicate(criteria, filter);

                if (action == "Remove")
                {
                    quests.RemoveAll(predicate);
                }
                else if (action == "Double")
                {
                    for (int i = 0; i < quests.Count; i++)
                    {
                        var currentQuest = quests[i];

                        if (predicate(currentQuest))
                        {
                            quests.Insert(i, currentQuest);
                            i++;
                        }
                    }
                }
            }

            if (quests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", quests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string criteria, string filter)
        {
            Predicate<string> predicate = criteria switch
            {
                "StartsWith" => x => x.StartsWith(filter),
                "EndsWith" => x => x.EndsWith(filter),
                "Length" => x => x.Length == int.Parse(filter),
                _ => null
            };

            return predicate;
        }
    }
}
