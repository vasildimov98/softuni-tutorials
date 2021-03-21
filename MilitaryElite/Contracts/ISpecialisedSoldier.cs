namespace MilitaryElite.Contracts
{
    using MilitaryElite.Enumerators;
    public interface ISpecialisedSoldier : ISoldier
    {
        Corps Corps { get; }
    }
}
