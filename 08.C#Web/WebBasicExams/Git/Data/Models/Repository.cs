namespace Git.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DbContextConstant;

    public class Repository
    {
        [Required]
        public string Id { get; init; } = Guid
            .NewGuid()
            .ToString();

        [Required]
        [MaxLength(RepositoryNameMinLength)]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsPublic { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
                = new HashSet<Commit>();
    }
}
