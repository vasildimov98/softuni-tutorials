namespace Git.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Git.Data;
    using Git.Models.Commits;
    using Git.Models.Repositpries;
    using Git.Models.Users;

    using static Data.DbContextConstant;

    public class Validator : IValidator
    {
        private readonly IUsersService usersService;
        private readonly ApplicationDbContext dbContext;

        public Validator(
            IUsersService usersService,
            ApplicationDbContext dbContext)
        {
            this.usersService = usersService;
            this.dbContext = dbContext;
        }

        public IEnumerable<string> ValidateCommitFormModel(CommitFormModel inputForm)
        {
            var errors = new List<string>();

            if (inputForm.Description == null
                || inputForm.Description.Length < CommitDescriptionMinLength)
            {
                errors.Add($"Description too short. Min Length: {CommitDescriptionMinLength}");
            }

            if (!dbContext.Repositories
                .Any(x => x.Id == inputForm.Id))
            {
                errors.Add($"Invalid repo Id.");
            }

            return errors;
        }

        public IEnumerable<string> ValidateRegisterFormModel(RegisterUserFormModel inputForm)
        {
            var errors = new List<string>();

            if (inputForm.Username == null
                || inputForm.Username.Length < UsernameMinLength
                || inputForm.Username.Length > UsernameMaxLength)
            {
                errors
                    .Add($"Username '{inputForm.Username}' should be between {UsernameMinLength} and {UsernameMaxLength} length inclusive");
            }

            if (this.usersService
                .IsUsernameAvailable(inputForm.Username))
            {
                errors
                    .Add($"Username '{inputForm.Username}' is taken");
            }

            if (inputForm.Email == null)
            {
                errors
                    .Add("Email is required");
            }

            if (this.usersService
                .IsEmailAvailable(inputForm.Email))
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

            return errors;
        }

        public IEnumerable<string> ValidateRepositoryFormModel(RepositoryFormModel inputForm)
        {
            var errors = new List<string>();

            if (inputForm.Name == null
                || inputForm.Name.Length < RepositoryNameMinLength
                || inputForm.Name.Length > RepositoryNameMaxLength)
            {
                errors
                    .Add($"Name '{inputForm.Name}' should be between {RepositoryNameMinLength} and {RepositoryNameMaxLength} length inclusive");
            }

            if (inputForm.RepositoryType == null
                || (inputForm.RepositoryType != RepositoryPrivateType
                && inputForm.RepositoryType != RepositoryPublicType))
            {
                errors
                     .Add($"RepositoryType is required. It should be either {RepositoryPrivateType} or {RepositoryPublicType}!");
            }

            return errors;
        }
    }
}
