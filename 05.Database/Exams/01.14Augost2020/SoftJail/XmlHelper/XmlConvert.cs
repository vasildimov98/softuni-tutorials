namespace SoftJail.XmlHelper
{
    using System.IO;
    using System.Xml.Serialization;
    using SoftJail.DataProcessor.ExportDto;

    public static class XmlConvert
    {
        public static T Deserialize<T>(string xmlString)
            where T : class
        {
            var xmlRoot = new XmlRootAttribute("Officers");
            var serializer = new XmlSerializer(typeof(T), xmlRoot);

            using var stringReader = new StringReader(xmlString);
            var result = serializer.Deserialize(stringReader) as T;

            return result;
        }
    }
}
