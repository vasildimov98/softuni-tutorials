namespace Git.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Commit
    {
        [Required]
        public string Id { get; init; } = Guid
            .NewGuid()
            .ToString();

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        [Required]
        public string RepositoryId { get; set; }

        public virtual Repository Repository { get; set; }
    }
}