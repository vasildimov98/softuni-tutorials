namespace P05.FootballTeamGenerator.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using P05.FootballTeamGenerator.Comman;
    public class Stats
    {
        private const int MIN_STAT_VALUE = 0;
        private const int MAX_STAT_VALUE = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Endurance));
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Sprint));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Dribble));
                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Passing));
                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                this.ValidateStat(value, nameof(this.Shooting));
                this.shooting = value;
            }
        }

        public double GetOverallLevelForPlayer()
        {
            return (this.Endurance
                + this.Sprint
                + this.Dribble
                + this.Passing
                + this.Shooting) / 5.0;
        }
        private void ValidateStat(int value, string typeOfStat)
        {
            if (value < MIN_STAT_VALUE || value > MAX_STAT_VALUE)
            {
                var message = string.Format(GlobalExeptionMessage.InvalidStatValueMessage, typeOfStat);
                throw new ArgumentException(message);
            }
        }
    }
}
