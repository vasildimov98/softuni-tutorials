namespace Students.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    public class Address
    {
        public int Id { get; set; }

        public string AddressText { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
