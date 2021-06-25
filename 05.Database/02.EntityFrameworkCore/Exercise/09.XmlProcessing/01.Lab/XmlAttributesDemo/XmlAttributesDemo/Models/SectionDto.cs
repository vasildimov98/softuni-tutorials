using System.Xml.Serialization;

namespace XmlAttributesDemo.Models
{
    [XmlType("section")]
    public class SectionDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlArray("books")]
        [XmlArrayItem("book")]
        public BookDto[] Books { get; set; }
    }
}