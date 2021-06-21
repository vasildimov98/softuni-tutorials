namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Reflection.PortableExecutable;

    public class Engine
    {
        private List<Person> people;
        public Engine()
        {
            this.people = new List<Person>();
        }
        public void Run()
        {
            GetAllPeople();

            var team = CreateTeam();
            PrintResultForTeam(team);
        }

        private Team CreateTeam()
        {
            var team = new Team("SoftUni");
            foreach (Person person in people)
            {
                team.AddPlayer(person);
            }
            return team;
        }

        private void GetAllPeople()
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();

                var person = (Person)null;
                try
                {
                    person = new Person(cmdArgs[0],
                                         cmdArgs[1],
                                         int.Parse(cmdArgs[2]),
                                         decimal.Parse(cmdArgs[3]));
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    continue;
                }

                people.Add(person);
            }
        }

        private void PrintResultForPeople()
        {
            var parcentage = decimal.Parse(Console.ReadLine());
            people.ForEach(p => p.IncreaseSalary(parcentage));
            people.ForEach(p => Console.WriteLine(p.ToString()));
        }

        private void PrintResultForTeam(Team team)
        {
            var firstTeamCount = team.FirstTeam.Count;
            var reserveTeamCount = team.ReserveTeam.Count;

            Console.WriteLine($"First team has {firstTeamCount} players.");
            Console.WriteLine($"Reserve team has {reserveTeamCount} players.");
        }
    }
}
