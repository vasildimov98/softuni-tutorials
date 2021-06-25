namespace CarDealer.Facade
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class XmlConverter
    {
        public static T DeserializeObject<T>(string rootName, string xml)
            where T : class
        {
            var xmlRootAttribute = new XmlRootAttribute(rootName);

            var serializer = new XmlSerializer(typeof(T), xmlRootAttribute);

            var output = serializer.Deserialize(new StringReader(xml)) as T;

            return output;
        }

        public static string SerializeObject<T>(string rootName, T dataTransferObject)
        {
            var xmlRootAttribute = new XmlRootAttribute(rootName);

            var serialier = new XmlSerializer(typeof(T), xmlRootAttribute);

            var sb = new StringBuilder();

            using var writer = new StringWriter(sb);

            serialier.Serialize(writer, dataTransferObject, GetEmptyNamespace());

            return sb.ToString();
        }

        private static XmlSerializerNamespaces GetEmptyNamespace()
        {
            var output = new XmlSerializerNamespaces();
            output.Add(string.Empty, string.Empty);
            return output;
        }
    }
}
