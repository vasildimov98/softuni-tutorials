namespace ProductShop.DTO.UserWithProducts
{
    public class UserSoldProductsDTO
    {
        public int Count { get; set; }

        public ProductInfoDTO[] Products { get; set; }
    }
}
