namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Project")]
    public class ExportXmlProjectDto
    {
        [XmlAttribute]
        public int TasksCount { get; set; }

        public string ProjectName { get; set; }

        public string HasEndDate { get; set; }

        public TaskXmlEmportDto[] Tasks { get; set; }
    }
}
