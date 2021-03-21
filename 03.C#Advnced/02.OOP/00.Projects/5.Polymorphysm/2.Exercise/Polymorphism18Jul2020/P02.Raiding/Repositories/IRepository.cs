namespace P02.Raiding.Repositories
{
    public interface IRepository<T>
    {
        int Count { get; }

        void Add(T model);
    }
}
