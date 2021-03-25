namespace BattleCards.Services
{
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;

    using Models;
    using Models.Data;

    public class UserService : IUserService
    {
        private BattleCardsDbContext context;

        public UserService(BattleCardsDbContext context)
        {
            this.context = context;
        }

        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = ConvertToHash(password),
            };

            this.context.Users.Add(user);

            this.context.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var user = this.context.Users
                .FirstOrDefault(x => x.Username == username);

            if (user?.Password != ConvertToHash(password))
                return null;

            return user.Id;
        }

        public bool IsEmailAvailable(string email)
            => !this.context.Users.Any(x => x.Email == email);

        public bool IsUsernameAvailable(string username)
            => !this.context.Users.Any(x => x.Username == username);

        private static string ConvertToHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}
