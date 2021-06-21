namespace P04.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class StartUp
    {
        private static List<Team> teams;
        public static void Main()
        {
            teams = new List<Team>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    ProceedCommand(command);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void ProceedCommand(string command)
        {
            var args = command
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

            var action = args[0];
            var teamName = args[1];

            var team = teams
                .FirstOrDefault(t => t.Name == teamName);

            if (action == "Team")
            {
                teams.Add(new Team(teamName));
            }
            else if (action == "Add")
            {
                ValidateTeam(teamName, team);

                var playerName = args[2];

                var endurance = int.Parse(args[3]);
                var sprint = int.Parse(args[4]);
                var dribble = int.Parse(args[5]);
                var passing = int.Parse(args[6]);
                var shooting = int.Parse(args[7]);

                var stats = new Stats(endurance, sprint, dribble, passing, shooting);

                var player = new Player(playerName, stats);

                team.AddPlayer(player);
            }
            else if (action == "Remove")
            {
                var playerName = args[2];
                team.RemovePlayer(playerName);
            }
            else
            {
                ValidateTeam(teamName, team);

                if (team != null)
                {
                    Console.WriteLine(team);
                }
            }
        }

        private static void ValidateTeam(string teamName, Team team)
        {
            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
        }
    }
}
