namespace CarShop.Data
{
    public class DbContextConstant
    {
        public const int DefaultMaxLength = 20;

        public const int MinUsernameLength = 4;
        public const int MinPasswordLength = 5;
        public const string MechanicType = "Mechanic";
        public const string ClientType = "Client";

        public const int MinCarModelLength = 5;
        public const int CarPlateNumberLength = 8;
        public const string ValidPlateNumberRegex = "^[A-Z]{2}[0-9]{4}[A-Z]{2}$";

        public const int MinIssueDescriptionLength = 5;
    }
}
