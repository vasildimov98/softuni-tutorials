namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        public const string MAIN_PLAYER_NAME = "Tommy Vercetti";
        public const int MAIN_PLAYER_HEALTH = 100;

        public MainPlayer()
            : base(MAIN_PLAYER_NAME, MAIN_PLAYER_HEALTH)
        {

        }
    }
}
