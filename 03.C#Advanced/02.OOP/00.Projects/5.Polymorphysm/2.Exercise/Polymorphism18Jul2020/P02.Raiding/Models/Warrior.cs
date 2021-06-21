namespace P02.Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int POWER = 100;

        public Warrior(string name)
            : base(name, POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{typeof(Warrior).Name} - {base.Name} hit for {base.Power} damage";
        }
    }
}
