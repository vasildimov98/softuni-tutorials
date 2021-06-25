namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    using Models;

    [XmlType(nameof(UserDTO))]
    public class ExportSellerDTO
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        [XmlArrayItem(nameof(Product))]
        public SoldProductDTO[] SoldProducts { get; set; }
    }

    [XmlType(nameof(Product))]
    public class SoldProductDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}

//<User>
//    <firstName>Almire</firstName>
//    <lastName>Ainslee</lastName>
//    <soldProducts>
//      <Product>
//        <name>olio activ mouthwash</name>
//        <price>206.06</price>
//      </Product>
//      <Product>
//        <name>Acnezzol Base</name>
//        <price>710.6</price>
//      </Product>
//      <Product>
//        <name>ENALAPRIL MALEATE</name>
//        <price>210.42</price>
//      </Product>
//    </soldProducts>
//  </User>...

