namespace VaporStore.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("Game")]
    public class GameXmlExportDto
    {
        [XmlAttribute("title")]
        public string Name { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}
