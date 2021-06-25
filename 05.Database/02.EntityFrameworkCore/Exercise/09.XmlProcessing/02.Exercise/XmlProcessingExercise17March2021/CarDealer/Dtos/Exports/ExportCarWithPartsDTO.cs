namespace CarDealer.DTOs.Exports
{
    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarWithPartsDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelDistance { get; set; }

        [XmlArray("parts")]
        public PartDTO[] Parts { get; set; }
    }

    [XmlType("part")]
    public class PartDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
