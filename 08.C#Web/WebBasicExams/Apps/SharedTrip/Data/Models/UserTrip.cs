namespace SharedTrip.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserTrip
    {
        [Required]
        public string UserId { get; init; } = Guid
                   .NewGuid()
                   .ToString();

        public User User { get; set; }

        [Required]
        public string TripId { get; init; } = Guid
                   .NewGuid()
                   .ToString();

        public Trip Trip { get; set; }
    }
}
