namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public Team()
        {
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
            this.Players = new HashSet<Player>();
        }

        public int TeamId { get; set; }

        [Required]
        [MaxLength(110)]
        public string Name { get; set; }

        [Required]
        public string LogoUrl { get; set; }

        [Required]
        [MaxLength(10)]
        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }
        [InverseProperty(nameof(Color.PrimaryKitTeams))]
        public virtual Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }
        [InverseProperty(nameof(Color.SecondaryKitTeams))]
        public virtual Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }
        public virtual Town Town { get; set; }

        public virtual ICollection<Game> HomeGames { get; set; }

        public virtual ICollection<Game> AwayGames { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
