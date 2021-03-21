namespace P02.Raiding.Contracts
{
    public interface IBaseHero
    {
        string Name { get; }
        int Power { get; }

        string CastAbility();
    }
}
