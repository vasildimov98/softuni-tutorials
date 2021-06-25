namespace CarDealer.DTOs.Exports
{
    using System.Xml.Serialization;
    [XmlType("car")]
    public class ExportCarWithDistanceDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelDistance { get; set; }
    }
}
