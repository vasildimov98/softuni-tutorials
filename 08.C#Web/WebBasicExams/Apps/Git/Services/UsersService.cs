namespace Git.Services
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using Git.Data;
    using Git.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext dbContext;

        public UsersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.HashPassword(password),
            };

            dbContext
                .Users
                .Add(user);

            dbContext.SaveChanges();

            return user.Id;
        }

        public string GetUserId(string username, string password)
                    => this.dbContext.Users
                          .Where(x => x.Username == username
                                   && x.Password == this.HashPassword(password))
                          .Select(x => x.Id)
                          .FirstOrDefault();

        public bool IsEmailAvailable(string email)
            => this.dbContext.Users
                .Any(x => x.Email == email);

        public bool IsUsernameAvailable(string username)
            => this.dbContext.Users
                .Any(x => x.Username == username);

        private string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }

            // Create a SHA256   
            using var sha256Hash = SHA256.Create();

            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert byte array to a string   
            var builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
