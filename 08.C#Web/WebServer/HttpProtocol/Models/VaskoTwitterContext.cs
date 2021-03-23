using Microsoft.EntityFrameworkCore;

namespace HttpProtocol.Models
{
    public partial class VaskoTwitterContext : DbContext
    {
        public VaskoTwitterContext()
        {
        }

        public VaskoTwitterContext(DbContextOptions<VaskoTwitterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tweet> Tweets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=VaskoTwitter;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Tweet>(entity =>
            {
                entity.Property(e => e.User).IsUnicode(false);

                entity.Property(e => e.VaskoTweet).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
