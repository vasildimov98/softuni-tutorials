namespace TeisterMask.DataProcessor.ImportDto
{
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;

    [XmlType("Project")]
    public class ProjectXmlImportDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        public string DueDate { get; set; }

        public TaskXmlImportDto[] Tasks { get; set; }
    }
}