namespace ProductShop.DTO.Import
{
    using Newtonsoft.Json;
    public class CategoryImportDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
