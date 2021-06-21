namespace P02.Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int POWER = 80;
        public Druid(string name)
            : base(name, POWER)
        {

        }

        public override string CastAbility()
        {
            return $"{typeof(Druid).Name} - {this.Name} healed for {this.Power}";
        }
    }
}
