namespace ProductShop.XmlHelper
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public static class XmlConverter
    {
        public static T DeserializeObject<T>(string root, string xml)
            where T : class
        {
            var rootAttribute = new XmlRootAttribute(root);
            var xmlSerializer = new XmlSerializer(typeof(T), rootAttribute);

            var userImportDtos = xmlSerializer.Deserialize(new StringReader(xml)) as T;

            return userImportDtos;
        }

        public static string SerializeObject<T>(string root, T objectToTransfer)
            where T : class
        {
            var rootAttribute = new XmlRootAttribute(root);
            var serialiezer = new XmlSerializer(typeof(T), rootAttribute);

            XmlSerializerNamespaces xmlNamespace = GetEmptyNameSpace();

            var sb = new StringBuilder();
            using (var writer = new StringWriter(sb))
            {
                serialiezer.Serialize(writer, objectToTransfer, xmlNamespace);
            }

            return sb.ToString().TrimEnd();
        }

        private static XmlSerializerNamespaces GetEmptyNameSpace()
        {
            var xmlNamespace = new XmlSerializerNamespaces();
            xmlNamespace.Add(string.Empty, string.Empty);
            return xmlNamespace;
        }
    }
}
