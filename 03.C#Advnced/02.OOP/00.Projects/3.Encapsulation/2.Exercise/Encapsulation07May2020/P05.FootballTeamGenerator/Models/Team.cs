namespace P05.FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P05.FootballTeamGenerator.Comman;
    public class Team
    {
        private string name;
        private List<Player> players;
        private Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name)
            :this()
        {
            this.Name = name;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                ValidateName(value);
                this.name = value;
            }
        }

        public int Rating => (int)Math.Round(players
            .Select(a => a.SkillLevel)
            .Sum(), MidpointRounding.AwayFromZero);

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            var player = this.players
                .FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                var message = string.Format(GlobalExeptionMessage.MissingPlayerMessage, name, this.Name);
                throw new ArgumentException(message);
            }

            this.players.Remove(player);
        }
        private void ValidateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                var message = GlobalExeptionMessage.InvalidNameMessage;
                throw new ArgumentException(message);
            }
        }
    }
}
