namespace CarDealer.DTO.Export
{
    using Newtonsoft.Json;

    public class SaleWithDiscountExport
    {
        [JsonProperty("car")]
        public CarSaleInfo Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount { get; set; }
    }

    public class CarSaleInfo
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }
    }
}
