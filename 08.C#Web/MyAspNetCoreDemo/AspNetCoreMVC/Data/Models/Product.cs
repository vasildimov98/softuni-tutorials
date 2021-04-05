namespace AspNetCoreMVC.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Models.Enum;
    using ValidationAttributes;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0.1, int.MaxValue)]
        public decimal Price { get; set; }

        public DateTime ArrivedOn { get; set; }

        [IsYearInRange(1989)]
        public int Year { get; set; }

        public ProductType Type { get; set; }

        [Required]
        public bool? IsAvailable { get; set; }
    }
}
