namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Models.Trips;
    using SharedTrip.Services;
    using System.Linq;

    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ITripsService tripsService;

        public TripsController(
            IValidator validator,
            ITripsService tripsService)
        {
            this.validator = validator;
            this.tripsService = tripsService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var model = this.tripsService
                .GetAllTrips();

            return this.View(model);
        }

        [Authorize]
        public HttpResponse Add()
            => this.View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(CreateTripFormModel inputForm)
        {
            var errors = this.validator
                .ValidateCreateTripFormModel(inputForm);

            if (errors.Any())
            {
                return Redirect("/Trips/Add");
            }

            this.tripsService.CreateTrip(inputForm);

            return this.Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            try
            {
                var trip = this.tripsService
                    .GetTripDetailsById(tripId);

                return this.View(trip);
            }
            catch (System.Exception)
            {
                return this.Redirect("/Trips/All");
            }
            
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var hasTripFreeSeat = this.tripsService
                .HasTripFreeSeat(tripId);

            if (!hasTripFreeSeat)
            {
                return this
                    .Redirect($"/Trips/Details?tripId={tripId}");
            }

            var isUserInTrip = this.tripsService
                .IsUserInTrip(this.User.Id, tripId);

            if (isUserInTrip)
            {
                return this
                    .Redirect($"/Trips/Details?tripId={tripId}");
            }

            this.tripsService.AddUserToTrip(this.User.Id, tripId);

            return this.Redirect("/Trips/All");
        }
    }
}
