namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(x => x.StudentId);

                entity
                    .Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity
                    .Property(x => x.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity
                    .Property(c => c.Name)
                    .HasMaxLength(80)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity
                    .Property(c => c.Description)
                    .IsUnicode(true)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity
                    .Property(r => r.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .IsRequired(true);

                entity
                    .Property(r => r.Url)
                    .IsUnicode(false)
                    .IsRequired(true);

                entity
                    .HasOne(r => r.Course)
                    .WithMany(c => c.Resources)
                    .HasForeignKey(r => r.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<HomeworkSubmission>(entity => 
            {
                entity.HasKey(hs => hs.HomeworkId);

                entity
                    .Property(hs => hs.Content)
                    .IsUnicode(false)
                    .IsRequired(true);

                entity
                    .HasOne(hs => hs.Student)
                    .WithMany(s => s.HomeworkSubmissions)
                    .HasForeignKey(hs => hs.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(hs => hs.Course)
                    .WithMany(c => c.HomeworkSubmissions)
                    .HasForeignKey(hs => hs.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StudentCourse>(entity => 
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity
                    .HasOne(sc => sc.Student)
                    .WithMany(s => s.Courses)
                    .HasForeignKey(sc => sc.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(sc => sc.Course)
                    .WithMany(c => c.Students)
                    .HasForeignKey(sc => sc.CourseId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);

            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
