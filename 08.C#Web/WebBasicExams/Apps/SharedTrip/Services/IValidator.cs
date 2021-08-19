namespace SharedTrip.Services
{
    using System.Collections.Generic;

    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;

    public interface IValidator
    {
        IEnumerable<string> ValidateRegisterFormModel(RegisterUserFormModel inputForm);

        IEnumerable<string> ValidateCreateTripFormModel(CreateTripFormModel inputForm);
    }
}
