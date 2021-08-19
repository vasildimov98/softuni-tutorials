namespace SharedTrip.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using SharedTrip.Data;
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;

    using static Data.DbDataConstant;
    using System;

    public class Validator : IValidator
    {
        private readonly ApplicationDbContext dbContext;

        public Validator(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<string> ValidateCreateTripFormModel(CreateTripFormModel inputForm)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(inputForm.StartPoint))
            {
                errors.Add("StartPoint is required");
            }

            if (string.IsNullOrWhiteSpace(inputForm.EndPoint))
            {
                errors.Add("EndPoint is required");
            }

            var isParsed = DateTime.TryParse(inputForm.DepartureTime, out var result);

            if (!isParsed)
            {
                errors.Add("Invalid date, date is required!");
            }

            if (inputForm.Seats < TripSeatsMinLength
                || inputForm.Seats > TripSeatsMaxLength)
            {
                errors
                .Add($"Seats are not in valid range. Min {TripSeatsMinLength} and Max {TripSeatsMaxLength}!");
            }

            if (inputForm.Description == null
                ||  inputForm.Description.Length > TripDescriptionMaxLength)
            {
                errors.Add($"Description is invalid. Its required and it should be less than {TripDescriptionMaxLength} symbols!");
            }

            return errors;
        }

        public IEnumerable<string> ValidateRegisterFormModel(RegisterUserFormModel inputForm)
        {
            var errors = new List<string>();

            if (inputForm.Username == null
                || inputForm.Username.Length < UsernameMinLength
                || inputForm.Username.Length > DefaultMaxLength)
            {
                errors
                    .Add($"Username '{inputForm.Username}' is invalid. IT should be between {UsernameMinLength} and {DefaultMaxLength} length inclusive");
            }

            var IsUsernameTaken = this.dbContext.Users
                .Any(x => x.Username == inputForm.Username);

            if (IsUsernameTaken)
            {
                errors
                    .Add($"Username '{inputForm.Username}' is taken! Try another one!");
            }

            if (inputForm.Email == null)
            {
                errors
                    .Add("Email is required");
            }

            var isEmailTaken = this.dbContext.Users
                .Any(x => x.Email == inputForm.Email);

            if (isEmailTaken)
            {
                errors
                    .Add($"Email '{inputForm.Email}' is taken");
            }

            if (inputForm.Password == null
                || inputForm.Password.Length < PasswordMinLength
                || inputForm.Password.Length > PasswordMaxLength)
            {
                errors
                    .Add($"Password is required and it should be between {PasswordMinLength} and {PasswordMaxLength} inclusive");
            }

            if (inputForm.Password.Contains(" "))
            {
                errors.Add("Whitespaces are not allowed in the password");
            }

            return errors;
        }
    }
}
