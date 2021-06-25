namespace ProductShop.DTO.Import
{
    public class ProductImportDto
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int SellerId { get; set; }
        public int? BuyerId { get; set; }
    }
}
