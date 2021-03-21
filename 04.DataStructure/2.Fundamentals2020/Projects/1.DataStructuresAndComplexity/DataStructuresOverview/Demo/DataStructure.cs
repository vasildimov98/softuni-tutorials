namespace Demo
{
    public class DataStructure<T> : IAbstractationDataStructure<T>
    {
        public void Add(T value)
        {
           //The real implementation of the add method
        }

        public void Remove(T value)
        {
            throw new System.NotImplementedException();
        }

        public void Search(T value)
        {
            throw new System.NotImplementedException();
        }
    }
}
