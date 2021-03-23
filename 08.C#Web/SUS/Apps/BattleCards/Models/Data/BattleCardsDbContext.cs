namespace BattleCards.Models.Data
{
    using Microsoft.EntityFrameworkCore;

    public class BattleCardsDbContext : DbContext
    {
        public BattleCardsDbContext()
        {
        }

        public BattleCardsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<UserCard> UsersCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=BattleCardsSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserCard>()
                .HasKey(x => new { x.UserId, x.CardId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
