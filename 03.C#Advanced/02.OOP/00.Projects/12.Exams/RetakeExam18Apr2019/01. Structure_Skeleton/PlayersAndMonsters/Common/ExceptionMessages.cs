namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string InvalidPlayerUsername
            = "Player's username cannot be null or an empty string.";
        public const string InvalidPlayerHealth
            = "Player's health bonus cannot be less than zero.";
        public const string InvalidDamagePoints
            = "Damage points cannot be less than zero.";

        public const string InvalidCardName
          = "Card's name cannot be null or an empty string.";
        public const string InvalidCardDamagePoints
          = "Card's damage points cannot be less than zero.";
        public const string InvalidCardHealthPoints
          = "Card's HP cannot be less than zero.";

        public const string InvalidDeadPlayer
          = "Player is dead!";

        public const string InvalidNullPlayer
            = "Player cannot be null";
        public const string InvalidEqualPlayer
            = "Player {0} already exists!";

        public const string InvalidNullCard
          = "Card cannot be null!";
        public const string InvalidEqualCard
           = "Card {0} already exists!";

        public const string InvalidType
            = "{0} of this type does not exists!";
    }
}
