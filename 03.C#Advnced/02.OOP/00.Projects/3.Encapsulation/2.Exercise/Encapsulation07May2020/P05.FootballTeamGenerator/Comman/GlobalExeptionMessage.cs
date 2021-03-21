using System.Collections.Specialized;

namespace P05.FootballTeamGenerator.Comman
{
    class GlobalExeptionMessage
    {
        public static string InvalidStatValueMessage = 
            "{0} should be between 0 and 100.";
        public static string InvalidNameMessage =
           "A name should not be empty.";
        public static string MissingPlayerMessage =
            "Player {0} is not in {1} team.";
        public static string MissigTeamExeption =
            "Team {0} does not exist.";
    }
}
