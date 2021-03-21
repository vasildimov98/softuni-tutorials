namespace CollectionHierarchy.IO.Modules
{
    using System;
    using CollectionHierarchy.IO.Contracts;

    public class Reader : IReadable
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
