namespace ViceCity.Models.Players
{
    public class CivilPlayer : Player
    {
        public const int CIVIL_PLAYER_HEALTH = 50;

        public CivilPlayer(string name)
            : base(name, CIVIL_PLAYER_HEALTH)
        {

        }
    }
}
