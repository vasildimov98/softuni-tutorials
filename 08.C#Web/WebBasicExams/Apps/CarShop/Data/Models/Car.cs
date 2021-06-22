namespace CarShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DbContextConstant;

    public class Car
    {
        [Required]
        public string Id { get; init; } = Guid
          .NewGuid()
          .ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(CarPlateNumberLength)]
        public string PlateNumber { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
    }
}  