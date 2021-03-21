namespace P02.Raiding.Modules
{
    public class Rogue : BaseHero
    {
        private const int ROGUE_POWER = 80;
        public Rogue(string name)
            : base(name, ROGUE_POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {base.Name} hit for {base.Power} damage";
        }
    }
}
