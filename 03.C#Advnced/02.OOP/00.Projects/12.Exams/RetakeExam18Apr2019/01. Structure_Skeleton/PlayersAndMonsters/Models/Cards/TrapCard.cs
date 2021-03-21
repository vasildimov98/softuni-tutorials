namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int DEMAGE_POINTS = 120;
        private const int HEALTH_POINTS = 5;

        public TrapCard(string name)
            : base(name, DEMAGE_POINTS, HEALTH_POINTS)
        {

        }
    }
}
