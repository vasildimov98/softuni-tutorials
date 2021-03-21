namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;
    interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }

        void AddRepair(IRepair repair);
    }
}
