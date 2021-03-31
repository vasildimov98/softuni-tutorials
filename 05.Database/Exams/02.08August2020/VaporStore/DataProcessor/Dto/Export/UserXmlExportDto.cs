namespace VaporStore.DataProcessor.Dto.Export
{
    using System.Xml.Serialization;

    [XmlType("User")]
    public class UserXmlExportDto
    {
        [XmlAttribute("username")]
        public string Username { get; set; }

        public PurchaseXmlExportDto[] Purchases { get; set; }

        public decimal TotalSpent { get; set; }
    }
}
