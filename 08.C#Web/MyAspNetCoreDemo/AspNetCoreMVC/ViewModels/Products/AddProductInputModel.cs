namespace AspNetCoreMVC.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using Data.Models.Enum;
    using ValidationAttributes;

    public class AddProductInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.1, double.MaxValue)]
        public decimal? Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? ArrivedOn { get; set; }

        [IsYearInRange(1989)]
        public int? Year { get; set; }

        [Required]
        public ProductType Type { get; set; }

        public bool? IsAvailable { get; set; }

        [Required]
        public VendorInputModel Vendor { get; set; }

        public IEnumerable<string> Parts { get; set; }

        public IFormFile Image { get; set; }

    }
}
