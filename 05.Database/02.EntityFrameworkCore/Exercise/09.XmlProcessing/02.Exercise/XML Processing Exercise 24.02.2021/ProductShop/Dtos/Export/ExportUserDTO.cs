namespace ProductShop.Dtos.Export
{
    using ProductShop.Models;
    using System.Xml.Serialization;

    [XmlRoot("Users")]
    public class ExportUserDTO
    {
        [XmlElement("count")]
        public int UsersCount { get; set; }

        [XmlArray("users")]
        [XmlArrayItem(nameof(User))]
        public UserDTO[] Users { get; set; }
    }

    [XmlType("User")]
    public class UserDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProductsDTO SoldProducts { get; set; }
    }

    [XmlType("SoldProducts")]
    public class SoldProductsDTO
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        [XmlArrayItem(nameof(Product))]
        public ProductDTO[] Products { get; set; }
    }

    [XmlType(nameof(Product))]
    public class ProductDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}