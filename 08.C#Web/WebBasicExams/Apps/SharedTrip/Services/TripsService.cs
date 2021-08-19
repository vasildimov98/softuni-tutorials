namespace SharedTrip.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext dbContext;

        public TripsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateTrip(CreateTripFormModel input)
        {
            var trip = new Trip
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = DateTimeOffset.Parse(input.DepartureTime).UtcDateTime,
                Description = input.Description,
                ImagePath = input.ImagePath == "" ? null : input.ImagePath,
                Seats = input.Seats,
            };

            this.dbContext.Trips.Add(trip);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<TripsViewModel> GetAllTrips()
            => this.dbContext.Trips
                .Select(x => new TripsViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToLocalTime().ToString("dd.MM.yyyy HH:mm"),
                    Seats = x.Seats - x.UserTrips.Count(),
                })
                .ToList();

        public TripDetailsViewModel GetTripDetailsById(string id)
        {
            var trip = this.dbContext.Trips
                .Where(x => x.Id == id)
                .Select(x => new TripDetailsViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime
                        .ToLocalTime()
                        .ToString("dd.MM.yyyy HH:mm"),
                    Seats = x.Seats - x.UserTrips.Count(),
                    ImagePath = x.ImagePath,
                    Description = x.Description,
                })
                .FirstOrDefault();

            if (trip == null)
            {
                throw new InvalidOperationException("Invalid trip id.");
            }

            return trip;
        }

        public void AddUserToTrip(string userId, string tripId)
        {
            var userTrip = new UserTrip
            {
                UserId = userId,
                TripId = tripId,
            };

            this.dbContext.UserTrips.Add(userTrip);

            this.dbContext.SaveChanges();
        }

        public bool IsUserInTrip(string userId, string tripId)
            => this.dbContext.UserTrips
            .Any(x => x.UserId == userId && x.TripId == tripId);

        public bool HasTripFreeSeat(string tripId)
            => this.dbContext.Trips
            .Any(x => x.Id == tripId && x.UserTrips.Count < x.Seats);
    }
}
