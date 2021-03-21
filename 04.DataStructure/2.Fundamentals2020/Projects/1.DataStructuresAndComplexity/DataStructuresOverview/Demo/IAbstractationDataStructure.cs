namespace Demo
{
    public interface IAbstractationDataStructure<T>
    {
        void Add(T value);

        void Remove(T value);

        void Search(T value);
    }
}
