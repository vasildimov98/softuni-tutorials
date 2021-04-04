namespace AspNetCoreMVC.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class VendorInputModel : IValidatableObject
    {
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression(@"[A-Z][a-z]{3,}", ErrorMessage = "Name should start with capital letter and have at least 3 letters afterwarts. Min Length 4, Max Lenght 30")]
        [Display(Name = "VendorName")]
        public string Name { get; set; }

        [MinLength(4)]
        public string Mark { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.Name))
                yield return new ValidationResult("Vendor name cannot be null or empty");
            if (string.IsNullOrWhiteSpace(this.Mark))
                yield return new ValidationResult("Mark cannot be null or empty!");
        }
    }
}