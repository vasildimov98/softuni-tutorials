namespace Students.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        public Town()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; }

        [InverseProperty("BirthTown")]
        public ICollection<Student> Citizens { get; set; }

        [InverseProperty("WorkTown")]
        public ICollection<Student> Students { get; set; }
    }
}
