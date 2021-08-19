namespace SharedTrip.Models.Trips
{
    public class TripsViewModel
    {
        public string Id { get; set; }

        public string StartPoint { get; init; }

        public string EndPoint { get; init; }

        public string DepartureTime { get; init; }

        public int Seats { get; init; }
    }
}
