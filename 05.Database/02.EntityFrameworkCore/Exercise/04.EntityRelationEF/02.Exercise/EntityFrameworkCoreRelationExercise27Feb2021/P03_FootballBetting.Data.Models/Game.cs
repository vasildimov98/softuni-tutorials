namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }

        public int GameId { get; set; }

        public int HomeTeamId { get; set; }
        [InverseProperty(nameof(Team.HomeGames))]
        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        [InverseProperty(nameof(Team.AwayGames))]
        public virtual Team AwayTeam { get; set; }


        public byte HomeTeamGoals { get; set; }

        public byte AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public double HomeTeamBetRate { get; set; }

        public double AwayTeamBetRate { get; set; }

        public double DrawBetRate { get; set; }

        [MaxLength(10)]
        public string Result { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}
