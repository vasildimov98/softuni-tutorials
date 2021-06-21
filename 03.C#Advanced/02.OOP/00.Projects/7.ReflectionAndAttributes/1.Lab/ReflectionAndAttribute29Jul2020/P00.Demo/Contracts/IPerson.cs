namespace P00.Demo.Contracts
{
    using System.Collections.Generic;
    interface IPerson : IAnimal
    {
        double Height { get; }
        IReadOnlyCollection<IAnimal> Animals { get; }
    }
}
