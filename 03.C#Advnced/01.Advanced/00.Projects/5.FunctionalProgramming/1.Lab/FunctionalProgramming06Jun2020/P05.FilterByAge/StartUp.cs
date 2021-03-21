namespace P05.FilterByAge
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        private static Dictionary<string, int> peopleInfo;
        public static void Main()
        {
            peopleInfo = new Dictionary<string, int>();

            var numberOfPeople = int.Parse(Console.ReadLine());

            GetAllPeople(numberOfPeople);

            var condition = Console.ReadLine();
            var ageFilter = int.Parse(Console.ReadLine());
            var formatType = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, ageFilter);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(formatType.ToLower());

            PrintFilteredPeople(peopleInfo, tester, printer);
        }

        private static void PrintFilteredPeople(Dictionary<string, int> peopleInfo, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            peopleInfo
                .Where(kvp => tester(kvp.Value))
                .ToList()
                .ForEach(printer);
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string formatType)
        {
            return formatType switch
            {
                "name age" => kvp => Console.WriteLine($"{kvp.Key} - {kvp.Value}"),
                "name" => kvp => Console.WriteLine($"{kvp.Key}"),
                "age" => kvp => Console.WriteLine($"{kvp.Value}"),
                _ => null
            };
        }

        private static Func<int, bool> CreateTester(string condition, int ageFilter)
        {
            return condition switch
            {
                "older" => age => age >= ageFilter,
                "younger" => age => age < ageFilter,
                _ => age => true
            };
        }

        private static void GetAllPeople(int numberOfPeople)
        {
            for (int i = 0; i < numberOfPeople; i++)
            {
                var personArgs = Console
                    .ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var personName = personArgs[0];
                var personAge = int.Parse(personArgs[1]);

                if (!peopleInfo.ContainsKey(personName))
                {
                    peopleInfo[personName] = personAge;
                }
            }
        }
    }
}
