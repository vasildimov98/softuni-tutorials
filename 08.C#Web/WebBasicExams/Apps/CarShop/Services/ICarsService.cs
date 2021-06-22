namespace CarShop.Services
{
    using System.Collections.Generic;

    using CarShop.Models.Issues;

    public interface ICarsService
    {
        public IEnumerable<CarViewModel> GetAllCarsByType(bool isMechanic, string userId);

        public void CreateCar(CreateCarFormModel inputModel);
    }
}
