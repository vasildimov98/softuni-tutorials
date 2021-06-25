
namespace Students.EntittyConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Students.Models;
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .Property<string>("SSN")
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
