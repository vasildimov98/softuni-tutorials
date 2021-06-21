namespace P02.Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int POWER = 100;
        public Paladin(string name)
            : base(name, POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{typeof(Paladin).Name} - {base.Name} healed for {base.Power}";
        }
    }
}
