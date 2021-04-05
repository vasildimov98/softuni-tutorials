namespace AspNetCoreMVC.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class IsYearInRange : ValidationAttribute
    {
        private readonly int minYear;

        public IsYearInRange(int minYear)
        {
            this.minYear = minYear;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is int year)
            {
                if (year >= minYear
                    && year <= DateTime.Now.Year)
                {
                    return ValidationResult.Success;
                }
            }

            this.ErrorMessage = $"{value} is invalid year! Year value should be between {minYear} and {DateTime.Now.Year}";

            return new ValidationResult(this.ErrorMessage);
        }
    }
}
