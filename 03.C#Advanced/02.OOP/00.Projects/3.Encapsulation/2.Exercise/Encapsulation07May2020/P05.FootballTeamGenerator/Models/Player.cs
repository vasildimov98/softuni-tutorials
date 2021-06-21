namespace P05.FootballTeamGenerator.Models
{
    using System;
    using P05.FootballTeamGenerator.Comman;

    public class Player
    {
        private string name;
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
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

        public Stats Stats { get; }
        public double SkillLevel => this.Stats.GetOverallLevelForPlayer();
        private static void ValidateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                var message = GlobalExeptionMessage.InvalidNameMessage;
                throw new ArgumentException(message);
            }
        }
    }
}
