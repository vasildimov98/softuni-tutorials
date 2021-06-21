namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int DEMAGE_POINTS = 5;
        private const int HEALTH_POINTS = 80;

        public MagicCard(string name)
            : base(name, DEMAGE_POINTS, HEALTH_POINTS)
        {

        }
    }
}
