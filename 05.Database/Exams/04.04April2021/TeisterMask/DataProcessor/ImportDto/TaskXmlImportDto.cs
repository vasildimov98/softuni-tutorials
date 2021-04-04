namespace TeisterMask.DataProcessor.ImportDto
{
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel.DataAnnotations;
    using TeisterMask.Data.Models.Enums;

    [XmlType("Task")]
    public class TaskXmlImportDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string OpenDate { get; set; }

        [Required]
        public string DueDate { get; set; }

        public int ExecutionType { get; set; }

        public int LabelType { get; set; }
    }
}