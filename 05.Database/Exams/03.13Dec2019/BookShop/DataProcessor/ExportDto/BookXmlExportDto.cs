namespace BookShop.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Book")]
    public class BookXmlExportDto
    {
        [XmlAttribute]
        public int Pages { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }
    }
}