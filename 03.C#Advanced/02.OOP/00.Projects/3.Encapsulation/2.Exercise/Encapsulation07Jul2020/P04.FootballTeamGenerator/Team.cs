namespace P04.FootballTeamGenerator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Team
    {
        private string name;
        private double rating;
        private readonly ICollection<Player> players;

        public Team(string name)
        {
            this.Name = name;

            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }
        public int Rating
            => this.players.Count > 0 ?
        (int)Math.Round(this.players.Average(p => p.Stats.SkillLevel()), MidpointRounding.AwayFromZero) : 0;

        public void AddPlayer(Player player)
            => this.players.Add(player);
        public void RemovePlayer(string name)
        {
            var player = this.players
                .FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }

            this.players.Remove(player);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
