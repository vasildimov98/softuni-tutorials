namespace VaporStore.DataProcessor.Dto.Import
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Data.Models.Enums;

    [XmlType("Purchase")]
    public class PurchaseJsonImportDto
    {
        [Required]
        [XmlAttribute("title")]
        public string GameName { get; set; }

        [Required]
        public PurchaseType? Type { get; set; }

        [Required]
        [RegularExpression(@"[A-Z0-9]{4}\p{Pd}[A-Z0-9]{4}\p{Pd}[A-Z0-9]{4}")]
        public string Key { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}")]
        [XmlElement("Card")]
        public string CardNumber { get; set; }

        [Required]
        public string Date { get; set; }
    }
}