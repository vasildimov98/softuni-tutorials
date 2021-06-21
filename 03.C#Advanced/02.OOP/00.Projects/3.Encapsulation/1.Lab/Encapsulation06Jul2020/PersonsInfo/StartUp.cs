namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main()
        {
            var people = new List<Person>();
            GenerateAllPeole(people);

            var team = new Team("SoftUni");

            AddPeopleInPerson(people, team);

            PrintResult(team);
        }

        private static void PrintResult(Team team)
        {
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }

        private static void AddPeopleInPerson(List<Person> people, Team team)
        {
            foreach (var person in people)
            {
                team.AddPlayer(person);
            }
        }

        private static void GenerateAllPeole(List<Person> people)
        {
            var lines = int.Parse(Console.ReadLine());

            AddPeopleToList(lines, people);
        }

        private static void AddPeopleToList(int lines, List<Person> people)
        {
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    AddPerson(people);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void AddPerson(List<Person> persons)
        {
            var cmdArgs = Console.ReadLine().Split();
            var person = new Person(cmdArgs[0],
                                    cmdArgs[1],
                                    int.Parse(cmdArgs[2]),
                                    decimal.Parse(cmdArgs[3]));

            persons.Add(person);
        }
    }
}
