namespace CarShop.Services
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using CarShop.Models.Issues;
    using CarShop.Models.Users;

    using static Data.DbContextConstant;

    public class Validator : IValidator
    {
        private readonly IUsersService userService;

        public Validator(IUsersService userService)
        {
            this.userService = userService;
        }

        public IEnumerable<string> ValidateCarInputForm(CreateCarFormModel inputForm)
        {
            var errors = new List<string>();

            if (inputForm.Model == null
                || inputForm.Model.Length < MinCarModelLength
                || inputForm.Model.Length > DefaultMaxLength)
            {
                errors
                    .Add($"Model '{inputForm.Model}' is invalid. It should be between {MinCarModelLength} and {DefaultMaxLength} length inclusive!");
            }

            if (inputForm.Year < 1900
                && inputForm.Year > 2100)
            {
                errors
                    .Add($"Year '{inputForm.Year}' is invalid! Valid years are between 1900 and 2100");
            }

            if (string.IsNullOrWhiteSpace(inputForm.Image))
            {
                errors
                    .Add("Image is required.");
            }

            if (!Regex.IsMatch(inputForm.PlateNumber, ValidPlateNumberRegex))
            {
                errors
                   .Add("Plate number is invalid. Valid is: 2 Capital English letters, followed by 4 digits, followed by 2 Capital English letters");
            }

            return errors;
        }

        public IEnumerable<string> ValidateIssueInputForm(CreateIssueFormModel inputForm)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(inputForm.Description)
                || inputForm.Description.Length < MinIssueDescriptionLength)
            {
                errors
                    .Add($"Description too short! It should be at least {MinIssueDescriptionLength} length");
            }

            if (string.IsNullOrWhiteSpace(inputForm.CarId))
            {
                errors
                    .Add($"Car Id is required!");
            }

            return errors;
        }

        public IEnumerable<string> ValidateRegisterInputForm(RegisterUserFormModel inputForm)
        {
            var list = new List<string>();

            if (inputForm.Username == null
                || inputForm.Username.Length < MinUsernameLength
                || inputForm.Username.Length > DefaultMaxLength)
            {
                list
                    .Add($"Username '{inputForm.Username}' should be between {MinUsernameLength} and {DefaultMaxLength} length inclusive");
            }

            if (userService
                .IsUsernameAvailable(inputForm.Username))
            {
                list
                    .Add($"Username '{inputForm.Username}' is taken");
            }

            if (inputForm.Email == null)
            {
                list
                    .Add("Email is required");
            }

            if (userService
                .IsEmailAvailable(inputForm.Email))
            {
                list
                    .Add($"Email '{inputForm.Email}' is taken");
            }

            if (inputForm.Password == null
                || inputForm.Password.Length < MinPasswordLength
                || inputForm.Password.Length > DefaultMaxLength)
            {
                list
                    .Add($"Password is required and it should be between {MinPasswordLength} and {DefaultMaxLength} inclusive");
            }

            if (inputForm.UserType == null
                || (inputForm.UserType != MechanicType
                && inputForm.UserType != ClientType))
            {
                list
                    .Add($"UserType is invalid. It should be eather {MechanicType} or {ClientType}");
            }

            return list;
        }
    }
}
