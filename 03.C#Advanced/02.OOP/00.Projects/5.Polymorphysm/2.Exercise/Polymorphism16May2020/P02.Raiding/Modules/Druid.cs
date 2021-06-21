namespace P02.Raiding.Modules
{
    public class Druid : BaseHero
    {
        private const int DRUID_POWER = 80;
        public Druid(string name)
            : base(name, DRUID_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {base.Name} healed for {base.Power}";
        }
    }
}
