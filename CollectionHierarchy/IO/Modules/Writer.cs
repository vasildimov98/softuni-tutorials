namespace CollectionHierarchy.IO.Modules
{
    using System;
    using CollectionHierarchy.IO.Contracts;
    class Writer : IWritable
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
