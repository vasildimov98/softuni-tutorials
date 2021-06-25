namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext() { }

        public FootballBettingContext(DbContextOptions options) : base(options) { }

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TeamId);

                entity
                    .Property(t => t.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity
                    .Property(t => t.LogoUrl)
                    .IsUnicode(false)
                    .IsRequired();

                entity
                    .Property(t => t.Initials)
                    .IsUnicode(false)
                    .IsRequired();

                entity
                    .HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(t => t.Town)
                    .WithMany(t => t.Teams)
                    .HasForeignKey(t => t.TownId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Color>(entity =>
            {
                entity.HasKey(c => c.ColorId);

                entity
                    .Property(c => c.Name)
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .IsRequired(true);
            });

            builder.Entity<Town>(entity =>
            {
                entity.HasKey(t => t.TownId);

                entity
                    .Property(t => t.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .IsRequired();

                entity
                    .HasOne(t => t.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(t => t.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.CountryId);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(30)
                    .IsUnicode(true)
                    .IsRequired();
            });

            builder.Entity<Player>(entity =>
            {
                entity.HasKey(pl => pl.PlayerId);

                entity
                    .Property(pl => pl.Name)
                    .HasMaxLength(30)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity
                    .HasOne(pl => pl.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(pl => pl.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(pl => pl.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(pl => pl.PositionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Position>(entity =>
            {
                entity.HasKey(p => p.PositionId);

                entity
                    .Property(p => p.Name)
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .IsRequired(true);
            });

            builder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.PlayerId, ps.GameId });

                entity
                    .HasOne(ps => ps.Player)
                    .WithMany(pl => pl.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);
                
                entity
                    .Property(g => g.Result)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .IsRequired(false);

                entity
                    .HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(g => g.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId);
            });

            builder.Entity<Bet>(entity =>
            {
                entity.HasKey(b => b.BetId);

                entity
                    .HasOne(b => b.User)
                    .WithMany(us => us.Bets)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity
                    .Property(u => u.Username)
                    .IsUnicode(false)
                    .HasMaxLength(20)
                    .IsRequired(true);

                entity
                    .Property(u => u.Password)
                    .IsUnicode(false)
                    .IsRequired(true);

                entity
                    .Property(u => u.Email)
                    .IsUnicode(false)
                    .HasMaxLength(20)
                    .IsRequired(true);

                entity
                    .Property(u => u.Name)
                    .IsUnicode(true)
                    .HasMaxLength(20)
                    .IsRequired(true);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        }
    }
}
