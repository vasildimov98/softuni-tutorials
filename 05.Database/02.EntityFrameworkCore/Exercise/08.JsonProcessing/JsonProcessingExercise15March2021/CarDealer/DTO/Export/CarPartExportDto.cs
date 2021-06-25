namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;

    public class CarPartExportDto
    {
        [JsonProperty("car")]
        public CarExport Car { get; set; }

        [JsonProperty("parts")]
        public PartExport[] PartCars { get; set; }
    }
    public class CarExport
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }
    }

    public class PartExport
    {
        public string Name { get; set; }

        public string Price { get; set; }
    }
}
