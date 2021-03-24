namespace SUS.MVC
{
    using System.ComponentModel.DataAnnotations;
    public abstract class IdentityUser
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }
    }
}
