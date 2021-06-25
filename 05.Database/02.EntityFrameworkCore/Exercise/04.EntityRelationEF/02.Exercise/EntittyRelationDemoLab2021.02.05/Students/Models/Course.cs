namespace Students.Models
{
    using System.Collections.Generic;
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int RoomNumber { get; set; }

        public ICollection<StudentCourse> Students { get; set; }
    }
}
