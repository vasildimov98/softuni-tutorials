using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace XmlAttributesDemo.Models
{
    [XmlRoot("library")]
    [XmlType("library")]
    public class LibraryDto
    {
        [XmlAttribute("name")]
        public string LibraryName { get; set; }

        [XmlElement("sections")]
        public SectionDto Sections { get; set; }

        [XmlIgnore]
        public decimal CardPrice { get; set; }
    }
}
