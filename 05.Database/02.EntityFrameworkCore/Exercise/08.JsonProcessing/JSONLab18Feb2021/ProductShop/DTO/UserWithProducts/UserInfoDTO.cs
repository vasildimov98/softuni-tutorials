namespace ProductShop.DTO.UserWithProducts
{
    public class UserInfoDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public UserSoldProductsDTO SoldProducts { get; set; }
    }
}
