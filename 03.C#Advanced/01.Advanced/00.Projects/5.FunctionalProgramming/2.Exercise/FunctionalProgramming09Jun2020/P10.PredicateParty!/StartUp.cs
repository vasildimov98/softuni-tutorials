namespace P10.PredicateParty_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var listOfQuest = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            ProceedCommand(listOfQuest);

            PrintReport(listOfQuest);
        }

        private static void PrintReport(List<string> list)
        {
            var report = list.Count > 0 ?
                $"{string.Join(", ", list)} are going to the party!" :
                "Nobody is going to the party!";

            Console.WriteLine(report);
        }

        private static void ProceedCommand(List<string> list)
        {
            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                var args = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = args[0];
                var criteria = args[1];
                var parameter = args[2];

                var predicate = GetPredicate(criteria, parameter);
                var function = GetFunc(action, predicate);

                function(list);
            }
        }

        private static Func<List<string>, List<string>> GetFunc(string action, Predicate<string> pred)
        {
            if (action == "Remove")
            {
                return c =>
                {
                    for (int i = 0; i < c.Count; i++)
                    {
                        var curr = c[i];

                        if (pred(curr))
                        {
                            c.Remove(curr);
                            i--;
                        }
                    }

                    return c;
                };
            }
            else
            {
                return c =>
                {
                    for (int i = 0; i < c.Count; i++)
                    {
                        var curr = c[i];

                        if (pred(curr))
                        {
                            c.Insert(i, curr);
                            i++;
                        }
                    }

                    return c;
                };
            }
        }

        private static Predicate<string> GetPredicate(string criteria, string par)
        {
            return criteria switch
            {
                "StartsWith" => p => p.StartsWith(par),
                "EndsWith" => p => p.EndsWith(par),
                "Length" => p => p.Length == int.Parse(par),
                _ => p => true,
            };
        }
    }
}
