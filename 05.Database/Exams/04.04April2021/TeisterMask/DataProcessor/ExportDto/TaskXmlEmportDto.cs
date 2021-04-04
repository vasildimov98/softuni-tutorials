namespace TeisterMask.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Task")]
    public class TaskXmlEmportDto
    {
        public string Name { get; set; }

        public string Label { get; set; }
    }
}

