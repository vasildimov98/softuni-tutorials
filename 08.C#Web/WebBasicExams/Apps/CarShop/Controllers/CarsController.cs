namespace CarShop.Controllers
{
    using CarShop.Models.Issues;
    using CarShop.Services;

    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ICarsService carsService;
        private readonly IValidator validator;

        public CarsController(
            IUsersService usersService,
            ICarsService carsService,
            IValidator validator)
        {
            this.usersService = usersService;
            this.carsService = carsService;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse All()
        {
            var isMechanic = this.usersService
                .IsUserMechanic(this.User.Id);

            var cars = this.carsService
                .GetAllCarsByType(isMechanic, this.User.Id);

            return this.View(cars);
        }

        [Authorize]
        public HttpResponse Add()
        {
            if(this.usersService.IsUserMechanic(this.User.Id))
            {
                return Error("Mechanics cannot add cars in the system");
            }

            return this.View();
        } 

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CreateCarFormModel input)
        {
            var errors = this.validator.ValidateCarInputForm(input);

            if (errors.Any())
            {
                return this.Error(errors);
            }

            input.OwnerId = this.User.Id;

            this.carsService.CreateCar(input);

            return this.Redirect("/Cars/All");
        }
    }
}
