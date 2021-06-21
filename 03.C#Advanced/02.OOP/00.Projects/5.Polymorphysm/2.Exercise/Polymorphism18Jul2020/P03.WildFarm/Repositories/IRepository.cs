namespace P03.WildFarm.Repositories
{
    using System.Collections.Generic;
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T animal);
    }
}
