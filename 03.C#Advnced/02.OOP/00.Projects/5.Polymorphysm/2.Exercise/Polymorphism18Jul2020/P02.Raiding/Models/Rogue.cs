namespace P02.Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int POWER = 80;

        public Rogue(string name)
            : base(name, POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{typeof(Rogue).Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
