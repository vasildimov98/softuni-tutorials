namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DbDataConstant;

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

        public ICollection<UserTrip> UserTrips { get; set; }
            = new HashSet<UserTrip>();
    }
}
