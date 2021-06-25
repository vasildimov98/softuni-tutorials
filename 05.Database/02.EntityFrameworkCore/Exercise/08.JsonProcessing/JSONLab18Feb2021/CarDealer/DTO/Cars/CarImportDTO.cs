namespace CarDealer.DTO.Cars
{
    using CarDealer.Models;

    public class CarImportDTO
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public int[] PartsId { get; set; }
    }
}
