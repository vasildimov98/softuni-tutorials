
namespace SoftJail.DataProcessor.ImportDto
{
    using System.Xml.Serialization;

    using Data.Models;

    [XmlType(nameof(Prisoner))]
    public class PrisonerMessagesDto
    {
        [XmlElement(nameof(Prisoner.Id))]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string FullName { get; set; }

        [XmlElement(nameof(Prisoner.IncarcerationDate))]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public MessageDto[] EncryptedMessages { get; set; }
    }

    [XmlType("Message")]
    public class MessageDto
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
