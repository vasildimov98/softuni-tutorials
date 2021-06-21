namespace P05.FootballTeamGenerator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P05.FootballTeamGenerator.Comman;
    using P05.FootballTeamGenerator.Models;

    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    ProcessCommad(command);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommad(string command)
        {
            var cmdArg = command
                        .Split(';', StringSplitOptions.None);

            var action = cmdArg[0];

            if (action == "Team")
            {
                AddTeam(cmdArg);
            }
            else if (action == "Add")
            {
                AddPlayer(cmdArg);
            }
            else if (action == "Remove")
            {
                RemovePlayer(cmdArg);
            }
            else if (action == "Rating")
            {
                var team = GetTeam(cmdArg[1]);

                Console.WriteLine(team);
            }
        }

        private void RemovePlayer(string[] cmdArg)
        {
            var teamName = cmdArg[1];
            var team = GetTeam(teamName);

            var playerName = cmdArg[2];

            team.RemovePlayer(playerName);
        }

        private void AddPlayer(string[] cmdArg)
        {
            var team = GetTeam(cmdArg[1]);

            var playerName = cmdArg[2];

            Stats stats = GetStats(cmdArg);

            var player = new Player(playerName, stats);

            team.AddPlayer(player);
        }

        private static Stats GetStats(string[] cmdArg)
        {
            var endurance = int.Parse(cmdArg[3]);
            var sprint = int.Parse(cmdArg[4]);
            var dribble = int.Parse(cmdArg[5]);
            var passing = int.Parse(cmdArg[6]);
            var shooting = int.Parse(cmdArg[7]);

            var stats = new Stats(endurance, sprint, dribble, passing, shooting);
            return stats;
        }

        private Team GetTeam(string teamName)
        {
            var team = this.teams
                .FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                var message = string.Format(GlobalExeptionMessage.MissigTeamExeption, teamName);
                throw new ArgumentException(message);
            }

            return team;
        }

        private void AddTeam(string[] cmdArg)
        {
            var team = new Team(cmdArg[1]);
            teams.Add(team);
        }
    }
}
