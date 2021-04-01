namespace BookShop.DataProcessor.ImportDto
{
using System.ComponentModel.DataAnnotations;
    public class AuthorJsonImportDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(1)]
        public BookJsonImportDto[] Books { get; set; }
    }

    public class BookJsonImportDto
    {
        public int? Id { get; set; }
    }

}
