namespace CarDealer.Dtos.Import
{
    using System.Xml.Serialization;

    [XmlType("Car")]
    public class CarWithPartDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public PartId[] PartsIds { get; set; }
    }

    [XmlType("partId")]
    public class PartId
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
