namespace CarShop.Services
{
    using System.Linq;

    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Models.Issues;

    public class IssuesService : IIssuesService
    {
        private readonly ApplicationDbContext dbContext;

        public IssuesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddIssueToCar(string carId, string description)
        {
            var issue = new Issue
            {
                Description = description,
                CarId = carId,
            };

            this.dbContext.Issues
                .Add(issue);

            this.dbContext.SaveChanges();
        }

        public void FixedIssue(string cardId, string issueId)
        {
            var issue = this.dbContext.Issues
                .Where(x => x.Id == issueId && x.CarId == cardId)
                .FirstOrDefault();

            issue.IsFixed = true;

            this.dbContext
                .SaveChanges();
        }

        public void DeleteIssue(string cardId, string issueId)
        {
            var car = this.dbContext.Cars.Find(cardId);
            var issue = this.dbContext.Issues.Find(issueId);
            car.Issues.Remove(issue);
            this.dbContext.Issues.Remove(issue);

            this.dbContext.SaveChanges();
        }


        public CarIssuesViewModel GetCarIssuesByCarId(string carId)
        {
            var car = this.dbContext.Cars
                .Where(x => x.Id == carId)
                .Select(x => new CarIssuesViewModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    Year = x.Year,
                    Issues = x.Issues
                        .Select(x => new IssueViewModel
                        {
                            Id = x.Id,
                            Description = x.Description,
                            IsFixed = x.IsFixed ? "Yes" : "Not yet",
                        })
                })
                .FirstOrDefault();

            if (car == null)
            {
                throw new InvalidOperationExeption($"Invalid carId '{carId}'!");
            }

            return car;
        }
    }
}
