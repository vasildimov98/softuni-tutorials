namespace CarDealer.DTOs.Exports
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class ExportSaleDTO
    {
        [XmlElement("car")]
        public CarDTO Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public string PriceWithDiscount { get; set; }
    }

    [XmlType("car")]
    public class CarDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelDistance { get; set; }
    }
}
