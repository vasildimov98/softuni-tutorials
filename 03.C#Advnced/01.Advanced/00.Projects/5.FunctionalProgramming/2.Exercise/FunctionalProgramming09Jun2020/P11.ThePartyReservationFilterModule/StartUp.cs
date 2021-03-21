namespace P11.ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var listOfInvitations = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var listOfFilters = new List<string>();

            GetAllFilters(listOfFilters);

            listOfInvitations
                = FilterTheListOfQuests(listOfInvitations, listOfFilters);

            Console.WriteLine(string.Join(" ", listOfInvitations));
        }

        private static List<string> FilterTheListOfQuests(List<string> listOfInvitations, List<string> listOfFilters)
        {
            foreach (var filter in listOfFilters)
            {
                var funcArgs = filter
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var conditions = funcArgs[0];
                var parameter = funcArgs[1];

                var pred = GetPredicate(conditions, parameter);

                listOfInvitations = listOfInvitations
                               .Where(pred)
                               .ToList();
            }

            return listOfInvitations;
        }

        private static void GetAllFilters(List<string> listOfFilters)
        {
            string filters;
            while ((filters = Console.ReadLine()) != "Print")
            {
                var filterArgs = filters
                    .Split(';', 2, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = filterArgs[0];
                var filterInfo = filterArgs[1];

                if (action.Contains("Add"))
                {
                    listOfFilters.Add(filterInfo);
                }
                else
                {
                    listOfFilters.Remove(filterInfo);
                }
            }
        }

        private static Func<string, bool> GetPredicate(string con, string par)
        {
            return con switch
            {
                "Starts with" => q => !q.StartsWith(par),
                "Ends with" => q => !q.EndsWith(par),
                "Length" => q => q.Length != int.Parse(par),
                "Contains" => q => !q.Contains(par),
                _ => q => true
            };
        }
    }
}
