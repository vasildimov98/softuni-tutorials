namespace SpaceStation.Common
{
    public static class ExceptionMessages
    {
        public const string INVALID_ASTRONAUT_NAME
           = "Astronaut name cannot be null or empty.";
        public const string INVALID_ASTRONAUT_OXYGEN
           = "Cannot create Astronaut with negative oxygen!";

        public const string INVALID_PLANET_NAME
           = "Invalid name!";

        public const string INVALID_ASTRONAUT_TYPE
           = "Astronaut type doesn't exists!";

        public const string MISSING_ASTRONAUT
          = "Astronaut {0} doesn't exists!";
        public const string NOT_ENOUGHT_ASTRONAUT
          = "You need at least one astronaut to explore the planet";

        public const string INVALID_COMMAND
            = "Command not found! Try another one!";
    }
}
