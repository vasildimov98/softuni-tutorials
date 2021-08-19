namespace SharedTrip.Services
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    using SharedTrip.Data;
    using SharedTrip.Data.Models;

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
                Password = HashPassword(password),
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
                                   && x.Password == HashPassword(password))
                          .Select(x => x.Id)
                          .FirstOrDefault();

        private static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }

            using var sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            var builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
