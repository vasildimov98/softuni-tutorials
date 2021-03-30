namespace SoftJail.DataProcessor.ExportDto
{
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;
    using Data.Models.Enums;

    [XmlType(nameof(Officer))]
    public class OfficerPrisonerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [XmlElement("Name")]
        public string FullName { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlElement("Money")]
        public decimal Salary { get; set; }

        [EnumDataType(typeof(Position))]
        [XmlElement("Position")]
        public string Position { get; set; }

        [EnumDataType(typeof(Weapon))]
        [XmlElement("Weapon")]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonerDto[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class PrisonerDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}