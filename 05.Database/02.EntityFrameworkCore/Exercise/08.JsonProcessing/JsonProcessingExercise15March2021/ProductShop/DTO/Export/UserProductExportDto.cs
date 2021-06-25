using Newtonsoft.Json;

namespace ProductShop.DTO.Export
{
    public class UserProductExportDto
    {
        [JsonProperty("usersCount")]
        public int UsersCount { get; set; }

        [JsonProperty("users")]
        public UserExportDto[] Users { get; set; }
    }

    public class UserExportDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("soldProducts")]
        public SoldProductExportDto SoldProducts { get; set; }
    }

    public class SoldProductExportDto
    {
        [JsonProperty("count")]
        public int ProductsSoldCount { get; set; }

        [JsonProperty("products")]

        public ProductExportDto[] Products { get; set; }
    }

    public class ProductExportDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}

