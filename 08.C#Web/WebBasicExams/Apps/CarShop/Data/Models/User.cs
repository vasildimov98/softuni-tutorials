namespace CarShop.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DbContextConstant;

    public class User
    {
        [Required]
        public string Id { get; init; } = Guid
            .NewGuid()
            .ToString();

        [Required]
        [MaxLength(DefaultMaxLength)]
        public string Username { get; set; } 

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsMechanic { get; set; }
    }
}

/*
•	Has a Username – a string with min length 4 
•	Has a Password – a string with min length 5 and max length 20  - hashed in the database (required)
*/
