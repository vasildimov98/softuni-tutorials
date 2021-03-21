namespace P02.Raiding.Modules
{
    public class Warrior : BaseHero
    {
        private const int WARRIOR_POWER = 100;
        public Warrior(string name)
            : base(name, WARRIOR_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {base.Name} hit for {base.Power} damage";
        }
    }
}
