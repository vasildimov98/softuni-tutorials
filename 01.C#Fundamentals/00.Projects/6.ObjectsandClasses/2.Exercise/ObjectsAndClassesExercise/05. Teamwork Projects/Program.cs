using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            CreatTeams(num, teams);
            GetMembers(teams);

            List<string> allDisbandingTeams = teams
                .Where(m => m.Members.Count == 0)
                .OrderBy(m => m.Name)
                .Select(n => n.Name)
                .ToList();

            teams.RemoveAll(m => m.Members.Count == 0);

            List<Team> sortedTeams = teams
                .OrderByDescending(m => m.Members.Count)
                .ThenBy(n => n.Name)
                .ToList();

            foreach (var team in sortedTeams)
            {
                Console.WriteLine(team);
            }
            Console.WriteLine("Teams to disband:");

            foreach (string team in allDisbandingTeams)
            {
                Console.WriteLine(team);
            }
        }

        private static void GetMembers(List<Team> teams)
        {
            string command = "";
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] data = command
                    .Split("->");

                string member = data[0];
                string name = data[1];

                Team existingTeam = teams.Find(n => n.Name == name);
                Team existingTeamMember = teams.Find(m => m.Members.Contains(member) || m.Creator == member);

                if (existingTeam == null)
                {
                    Console.WriteLine($"Team {name} does not exist!");
                    continue;
                }

                if (existingTeamMember != null)
                {
                    Console.WriteLine($"Member {member} cannot join team {name}!");
                    continue;
                }

                existingTeam.Members.Add(member);
            }
        }

        private static void CreatTeams(int num, List<Team> teams)
        {
            for (int i = 0; i < num; i++)
            {
                string[] data = Console
                    .ReadLine()
                    .Split("-")
                    .ToArray();
                string creator = data[0];
                string name = data[1];

                Team existingTeam = teams.Find(n => n.Name == name);
                Team existingTeamCreator = teams.Find(n => n.Creator == creator);
                if (existingTeam != null)
                {
                    Console.WriteLine($"Team {name} was already created!");
                    continue;
                }

                if (existingTeamCreator != null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team team = new Team(creator, name);
                teams.Add(team);
                Console.WriteLine($"Team {name} has been created by {creator}!");
            }
        }
    }

    class Team
    {
        public Team(string creator, string name)
        {
            Creator = creator;
            Name = name;
            Members = new List<string>();
        }

        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }

        public override string ToString()
        {
            List<string> sortedMembers = Members
                .OrderBy(m => m)
                .ToList();
            string output = $"{Name}\n";
            output += $"- {Creator}\n";

            for (int i = 0; i < Members.Count; i++)
            {
                output += $"-- {sortedMembers[i]}\n";
            }
            return output.Trim();
        }
    }
}
