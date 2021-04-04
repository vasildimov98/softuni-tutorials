namespace TeisterMask.XmlHelper
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public static class XmlConvert
    {
        public static T Deserialize<T>(string root, string xmlString)
            where T : class
        {
            var xmlRoot = new XmlRootAttribute(root);
            var serializer = new XmlSerializer(typeof(T), xmlRoot);

            using var stringReader = new StringReader(xmlString);
            var result = serializer.Deserialize(stringReader) as T;

            return result;
        }

        public static string Serialize<T>(string xmlRootName, T dto)
            where T : class
        {
            var xmlRoot = new XmlRootAttribute(xmlRootName);

            var serializer = new XmlSerializer(dto.GetType(), xmlRoot);

            var sb = new StringBuilder();
            using var stringWriter = new StringWriter(sb);
            serializer.Serialize(stringWriter, dto, GetEmptyNamespace());

            var xmlOutput = sb.ToString();

            return xmlOutput;
        }

        private static XmlSerializerNamespaces GetEmptyNamespace()
        {
            var namespaceOutput = new XmlSerializerNamespaces();

            namespaceOutput.Add(string.Empty, string.Empty);

            return namespaceOutput;
        }
    }
}
