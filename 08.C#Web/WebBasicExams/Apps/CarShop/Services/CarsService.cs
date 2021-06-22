namespace CarShop.Services
{
    using System.Linq;
    using System.Collections.Generic;

    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Models.Issues;

    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext dbContext;

        public CarsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateCar(CreateCarFormModel inputModel)
        {
            var car = new Car
            {
                Model = inputModel.Model,
                Year = inputModel.Year,
                PlateNumber = inputModel.PlateNumber,
                PictureUrl = inputModel.Image,
                OwnerId = inputModel.OwnerId,
            };

            this.dbContext.Cars.Add(car);

            this.dbContext.SaveChanges();
        }

        public IEnumerable<CarViewModel> GetAllCarsByType(bool isMechanic, string userId)
        {
            var carsAsQuery = this.dbContext.Cars
                .AsQueryable();  

            if (isMechanic)
            {
                carsAsQuery = carsAsQuery
                    .Where(x => x.Issues.Any(y => !y.IsFixed));
            }

            if (!isMechanic)
            {
                carsAsQuery = carsAsQuery
                    .Where(x => x.OwnerId == userId);
            }

            return carsAsQuery
                .Select(x => new CarViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    Year = x.Year,
                    PictureUrl = x.PictureUrl,
                    PlateNumber = x.PlateNumber,
                    FixedIssues = x.Issues
                        .Where(x => x.IsFixed)
                        .Count(),
                    RemainingIssues = x.Issues
                        .Where(x => !x.IsFixed)
                        .Count(),
                })
                .ToList();
        }
    }
}
