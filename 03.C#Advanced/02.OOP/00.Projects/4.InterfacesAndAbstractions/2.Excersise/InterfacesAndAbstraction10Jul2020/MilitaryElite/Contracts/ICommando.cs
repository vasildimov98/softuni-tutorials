using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    public interface ICommando
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}
