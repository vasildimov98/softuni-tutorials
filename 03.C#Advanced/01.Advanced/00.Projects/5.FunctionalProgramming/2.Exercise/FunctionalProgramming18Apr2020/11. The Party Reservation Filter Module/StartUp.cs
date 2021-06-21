using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class StartUp
    {
        static void Main()
        {
            var reservationQuests = Console
                 .ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            var filters = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                var cmdArg = command
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = cmdArg[0];
                var filter = cmdArg[1];
                var type = cmdArg[2];

                var predicate = GetPredicate(filter, type);

                if (action.Contains("Add"))
                {
                    filters.Add(filter + ":" + type);   
                }
                else if (action.Contains("Remove"))
                {
                    filters.Remove(filter + ":" + type);
                }
            }

            foreach (var cmd in filters)
            {
                var cmdArg = cmd
                    .Split(":");

                var filter = cmdArg[0];
                var type = cmdArg[1];

                var predicate = GetPredicate(filter, type.ToString());

               reservationQuests = reservationQuests
                    .Where(predicate)
                    .ToList();
            }

            Console.WriteLine(string.Join(" ", reservationQuests));
        }

        static Func<string, bool> GetPredicate(string filter, string type)
        {
            Func<string, bool> predicate = filter switch
            {
                "Starts with" => n => !n.StartsWith(type),
                "Ends with" => n => !n.EndsWith(type),
                "Length" => n => !(n.Length == int.Parse(type)),
                "Contains" => n => !n.Contains(type),
                _ => null
            };

            return predicate;
        }
    }
}
