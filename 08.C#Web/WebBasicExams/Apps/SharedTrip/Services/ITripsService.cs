namespace SharedTrip.Services
{
    using SharedTrip.Models.Trips;
    using System.Collections.Generic;

    public interface ITripsService
    {
        void CreateTrip(CreateTripFormModel input);

        IEnumerable<TripsViewModel> GetAllTrips();

        TripDetailsViewModel GetTripDetailsById(string id);

        public void AddUserToTrip(string userId, string tripId);

        public bool IsUserInTrip(string userId, string tripId);

        bool HasTripFreeSeat(string tripId);
    }
}
