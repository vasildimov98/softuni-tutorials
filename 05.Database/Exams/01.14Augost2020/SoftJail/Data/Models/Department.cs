﻿namespace SoftJail.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Department
    {
        public Department()
        {
            this.Cells = new HashSet<Cell>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual ICollection<Cell> Cells { get; set; }
    }
}
/*
•	Name – text with min length 3 and max length 25
*/
