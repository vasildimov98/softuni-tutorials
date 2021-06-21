namespace P02.Raiding.Modules
{
    using P02.Raiding.Conracts;

    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name, int power)
        {
           this.Name = name;
           this.Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; private set; }

        public abstract string CastAbility();
    }
}
