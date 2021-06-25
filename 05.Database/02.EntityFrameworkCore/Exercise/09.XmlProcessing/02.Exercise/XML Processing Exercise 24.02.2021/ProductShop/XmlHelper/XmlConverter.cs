namespace ProductShop.XmlHelper
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class XmlConverter
    {
        public static T DesirializeObject<T>(string rootName, string xml)
            where T : class
        {
            var rootAttr = new XmlRootAttribute(rootName);

            var serializer = new XmlSerializer(typeof(T), rootAttr);

            var output = serializer.Deserialize(new StringReader(xml)) as T;

            return output;
        }

        public static string SerializeObject<T>(string rootName, T dataTransferObject)
            where T : class
        {
            var rootAttr = new XmlRootAttribute(rootName);
            var serializer = new XmlSerializer(typeof(T), rootAttr);

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, dataTransferObject, GetEmptyNamespace());
            }

            return sb.ToString().TrimEnd();
        }

        private static XmlSerializerNamespaces GetEmptyNamespace()
        {
            var xmlNamespace = new XmlSerializerNamespaces();
            xmlNamespace.Add(string.Empty, string.Empty);
            return xmlNamespace;
        }
    }
}
