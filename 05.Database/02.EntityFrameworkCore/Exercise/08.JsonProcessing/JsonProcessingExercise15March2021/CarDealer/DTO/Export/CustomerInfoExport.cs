namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;

    public class CustomerInfoExport
    {
        [JsonProperty("fullName")]
        public string Name { get; set; }

        [JsonProperty("boughtCars")]
        public int SalesCount { get; set; }

        [JsonProperty("spentMoney")]
        public decimal SpentMoney { get; set; }
    }
}
