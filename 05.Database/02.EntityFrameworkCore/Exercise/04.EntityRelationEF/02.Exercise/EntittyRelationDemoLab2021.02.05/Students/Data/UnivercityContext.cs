namespace Students.Data
{
    using Microsoft.EntityFrameworkCore;
    using Students.EntittyConfiguration;

    using Students.Models;

    public class UnivercityContext : DbContext
    {
        private const string DB_DEFFAULT_CONNECTION_TEXT = "Server=.;Database=Univercity;Integrated Security=true";
        public UnivercityContext()
        {
        }

        public UnivercityContext(DbContextOptions<UnivercityContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Student)
                .WithOne(s => s.Address)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Town>()
                .HasMany(t => t.Addresses)
                .WithOne(a => a.Town)
                .HasForeignKey(a => a.TownId);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(sc => sc.CourseId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DB_DEFFAULT_CONNECTION_TEXT);
            }
        }
    }
}
