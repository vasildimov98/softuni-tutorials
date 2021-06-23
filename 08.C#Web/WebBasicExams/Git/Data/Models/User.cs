namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DbContextConstant;

    public class User
    {
        [Required]
        public string Id { get; init; } = Guid
                     .NewGuid()
                     .ToString();

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Repository> Repositories { get; set; } 
            = new HashSet<Repository>();

        public virtual ICollection<Commit> Commits { get; set; }
            = new HashSet<Commit>();
    }
}
