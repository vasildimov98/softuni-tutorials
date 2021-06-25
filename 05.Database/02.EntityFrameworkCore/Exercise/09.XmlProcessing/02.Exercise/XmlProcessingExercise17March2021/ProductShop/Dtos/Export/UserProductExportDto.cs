namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;
    [XmlType("Users")]
    public class UsersInfoExportDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserProductExportDto[] Users { get; set; }
    }


    [XmlType("User")]
    public class UserProductExportDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }
        
        public SoldProducts SoldProducts { get; set; }
    }

    public class SoldProducts
    {
        [XmlElement("count")]
        public int ProductsSoldCount { get; set; }

        [XmlArray("products")]
        public ProductExport[] Products { get; set; }
    }

    [XmlType("Product")]
    public class ProductExport
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
