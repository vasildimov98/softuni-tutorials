namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Config;
    using Models;

    public class SalesContext : DbContext
    {
        public SalesContext() { }

        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity
                    .Property(c => c.Description)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity => 
            {
                entity
                    .Property(c => c.Email)
                    .HasDefaultValue("No description");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity
                    .Property(s => s.Date)
                    .HasDefaultValueSql("GETDATE()");

                entity
                    .HasOne(s => s.Product)
                    .WithMany(pr => pr.Sales)
                    .HasForeignKey(s => s.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                   .HasOne(s => s.Customer)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

                entity
                   .HasOne(s => s.Store)
                   .WithMany(st => st.Sales)
                   .HasForeignKey(s => s.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.CONFIGURATION_TEXT);
            }
        }
    }
}
