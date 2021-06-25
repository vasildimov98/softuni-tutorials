namespace Students.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StudentInfo")]
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<StudentCourse>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string StudentName { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(nameof(FacultyNumber), TypeName = "varchar")]
        public string FacultyNumber { get; set; }

        [NotMapped]
        public string Department { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<StudentCourse> Courses { get; set; }

        public Town BirthTown { get; set; }

        public Town WorkTown { get; set; }
    }
}
