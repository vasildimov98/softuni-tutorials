namespace SUS.MVCFramework
{
    using System.ComponentModel.DataAnnotations;
    public abstract class IdentityUser<T>
    {
        public IdentityUser()
        {
            this.Role = IdentityRole.User;
        }

        public T Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Password { get; set; }

        public IdentityRole Role { get; set; }
    }
}
