namespace CarShop.Services
{
    using System.Collections.Generic;

    using CarShop.Models.Issues;
    using CarShop.Models.Users;

    public interface IValidator
    {
        IEnumerable<string> ValidateRegisterInputForm(RegisterUserFormModel inputForm);

        IEnumerable<string> ValidateCarInputForm(CreateCarFormModel inputForm);

        IEnumerable<string> ValidateIssueInputForm(CreateIssueFormModel inputForm);

    }
}
