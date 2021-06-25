namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<StudentCourse>();
            this.HomeworkSubmissions = new HashSet<HomeworkSubmission>();
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<StudentCourse> Courses { get; set; }

        public virtual ICollection<HomeworkSubmission> HomeworkSubmissions { get; set; }
    }
}
