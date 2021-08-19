namespace Git.Services
{
    using System.Collections.Generic;

    using Git.Models.Commits;
    using Git.Models.Repositpries;
    using Git.Models.Users;

    public interface IValidator
    {
        IEnumerable<string> ValidateRegisterFormModel(RegisterUserFormModel inputForm);

        IEnumerable<string> ValidateRepositoryFormModel(RepositoryFormModel inputForm);

        IEnumerable<string> ValidateCommitFormModel(CommitFormModel inputForm);
    }
}
