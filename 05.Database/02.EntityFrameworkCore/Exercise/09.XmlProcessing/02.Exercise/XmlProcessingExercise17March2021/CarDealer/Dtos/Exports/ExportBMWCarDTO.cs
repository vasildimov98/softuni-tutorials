namespace CarDealer.DTOs.Exports
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportBMWCarDTO
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelDistance { get; set; }
    }
}
