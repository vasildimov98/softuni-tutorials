namespace CarDealer.DTOs.Imports
{
    using System.Xml.Serialization;

    using Models;

    [XmlType(nameof(Car))]
    public class ImportCarDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelDistance { get; set; }

        [XmlArray("parts")]
        public PartIdDTO[] PartsIds { get; set; }
    }

    [XmlType("partId")]
    public class PartIdDTO
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
