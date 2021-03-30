namespace SoftJail.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Enums;

    public class Officer
    {
        public Officer()
        {
            this.OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FullName { get; set; }

        public decimal Salary { get; set; }

        public Position Position { get; set; }

        public Weapon Weapon { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}

/*
•	FullName – text with min length 3 and max length 30 (required)
•	Salary – decimal (non-negative, minimum value: 0) (required)
•	Position - Position enumeration with possible values: “” (required)
•	Weapon - Weapon enumeration with possible values: “” (required)
•	Department – the officer's department (required)
•	OfficerPrisoners - collection of type OfficerPrisoner
*/
