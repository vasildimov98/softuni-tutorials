namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext() { }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity
                    .Property(x => x.LogoUrl)
                    .IsUnicode(false);

                entity
                    .Property(x => x.LogoUrl)
                    .IsUnicode(false);

                entity
                    .Property(x => x.Initials)
                    .IsUnicode(false);

                entity
                    .HasOne(x => x.PrimaryKitColor)
                    .WithMany(x => x.PrimaryKitTeams)
                    .HasForeignKey(x => x.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                   .HasOne(x => x.SecondaryKitColor)
                   .WithMany(x => x.SecondaryKitTeams)
                   .HasForeignKey(x => x.SecondaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(x => new { x.PlayerId, x.GameId });
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                    .Property(x => x.Result)
                    .IsUnicode(false);

                entity
                    .HasOne(x => x.HomeTeam)
                    .WithMany(x => x.HomeGames)
                    .HasForeignKey(x => x.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(x => x.AwayTeam)
                    .WithMany(x => x.AwayGames)
                    .HasForeignKey(x => x.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity
                    .Property(x => x.Username)
                    .IsUnicode(false);

                entity
                    .Property(x => x.Password)
                    .IsUnicode(false);

                entity
                    .Property(x => x.Email)
                    .IsUnicode(false);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=.;Database=FootballBookmakerSystem;Integrated Security=True");
        }
    }
}
