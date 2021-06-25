namespace ProductShop.DTO.User
{
    public class UserDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ProductUserDTO[] SoldProducts { get; set; }
    }
}
