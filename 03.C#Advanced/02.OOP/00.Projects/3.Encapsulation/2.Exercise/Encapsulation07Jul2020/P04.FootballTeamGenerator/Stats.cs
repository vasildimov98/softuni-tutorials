namespace P04.FootballTeamGenerator
{
    using System;

    public class Stats
    {
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;

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
            get => this.endurance;
            private set
            {
                this.ValidateStats(nameof(this.Endurance), value);

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                this.ValidateStats(nameof(this.Sprint), value);

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                this.ValidateStats(nameof(this.Dribble), value);

                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                this.ValidateStats(nameof(this.Passing), value);

                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                this.ValidateStats(nameof(this.Shooting), value);

                this.shooting = value;
            }
        }

        public double SkillLevel()
        {
            var countOfSpits = 5.0;

            return (this.Endurance
                + this.Sprint
                + this.Dribble
                + this.Passing
                + this.Shooting) / countOfSpits;
        }

        private void ValidateStats(string type, int stats)
        {
            if (stats < MIN_STAT || stats > MAX_STAT)
            {
                throw new ArgumentException($"{type} should be between {MIN_STAT} and {MAX_STAT}.");
            }
        }
    }
}
