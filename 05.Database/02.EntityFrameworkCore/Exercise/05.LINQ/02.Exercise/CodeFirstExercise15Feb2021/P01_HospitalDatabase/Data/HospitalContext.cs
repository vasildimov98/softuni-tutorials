namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Config;
    using Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext() { }

        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                    .Property(p => p.Email)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PatientMedicament> (entity =>
            {
                entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionText);
            }
        }
    }
}
