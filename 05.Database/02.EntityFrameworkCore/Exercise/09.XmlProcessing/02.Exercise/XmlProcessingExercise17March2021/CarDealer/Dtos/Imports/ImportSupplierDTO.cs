namespace CarDealer.DTOs.Imports
{
    using System.Xml.Serialization;

    using Models;

    [XmlType(nameof(Supplier))]
    public class ImportSupplierDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
