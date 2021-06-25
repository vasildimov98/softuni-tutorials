namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("suplier")]
    public class SupplierExportDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("part-count")]
        public int PartsCount { get; set; }
    }
}
