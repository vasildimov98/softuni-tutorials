namespace CarShop.Controllers
{
    using CarShop.Models.Issues;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System;
    using System.Linq;

    public class IssuesController : Controller
    {
        private readonly IIssuesService issuesService;
        private readonly IValidator validator;
        private readonly IUsersService usersService;

        public IssuesController(
            IIssuesService issuesService,
            IValidator validator,
            IUsersService usersService)
        {
            this.issuesService = issuesService;
            this.validator = validator;
            this.usersService = usersService;
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            try
            {
                var car = this.issuesService
                .GetCarIssuesByCarId(carId);

                car.IsMechanic = this.usersService
                    .IsUserMechanic(this.User.Id);

                return this.View(car);
            }
            catch (InvalidOperationExeption ioe)
            {
                return this.Error(ioe.Message);
            }
        }


        [Authorize]
        public HttpResponse Add(string carId)
            => this.View(new CarIdViewModel { CarId = carId });


        [HttpPost]
        [Authorize]
        public HttpResponse Add(CreateIssueFormModel input)
        {
            try
            {
                var errors = this.validator
                    .ValidateIssueInputForm(input);

                if (errors.Any())
                {
                    return this.Error(errors);
                }

                this.issuesService
                .AddIssueToCar(input.CarId, input.Description);

                return this.Redirect($"/Issues/CarIssues?carId={input.CarId}");
            }
            catch (Exception ex)
            {
                return this.Error(ex.Message);
            }
        }

        [Authorize]
        public HttpResponse Fix(string carId, string issueId)
        {
            if (!this.usersService.IsUserMechanic(this.User.Id))
            {
                return this.Error("Clients cannot fix Issues");
            }

            try
            {
                this.issuesService.FixedIssue(carId, issueId);

                return this.Redirect($"/Issues/CarIssues?carId={carId}");
            }
            catch (Exception ex)
            {
                return this.Error(ex.Message);
            }
        }

        [Authorize]
        public HttpResponse Delete(string carId, string issueId)
        {
            try
            {
                this.issuesService.DeleteIssue(carId, issueId);

                return this.Redirect($"/Issues/CarIssues?carId={carId}");
            }
            catch (Exception ex)
            {
                return this.Error(ex.Message);
            }
        }
    }
}
