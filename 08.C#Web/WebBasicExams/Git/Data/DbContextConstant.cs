namespace Git.Data
{
    public class DbContextConstant
    {
        public const int UsernameMaxLength = 20;
        public const int UsernameMinLength = 5;
        public const int PasswordMaxLength = 20;
        public const int PasswordMinLength = 6;

        public const int RepositoryNameMaxLength = 10;
        public const int RepositoryNameMinLength = 3;
        public const string RepositoryPublicType = "Public";
        public const string RepositoryPrivateType = "Private";

        public const int CommitDescriptionMinLength = 5;

    }
}
