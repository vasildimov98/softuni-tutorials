namespace CarDealer.DTOs.Imports
{
    using Models;
    using System.Xml.Serialization;

    [XmlType(nameof(Sale))]
    public class ImportSaleDTO
    {
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }
    }
}
