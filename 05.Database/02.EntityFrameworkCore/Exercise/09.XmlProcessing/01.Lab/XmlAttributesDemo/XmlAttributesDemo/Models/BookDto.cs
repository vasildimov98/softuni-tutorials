using System.Xml.Serialization;

namespace XmlAttributesDemo.Models
{
    [XmlType("book")]
    public class BookDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlText]
        public string Description { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }
    }
}