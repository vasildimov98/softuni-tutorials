namespace P03.WildFarm.IO.Modules
{
    using System;

    using P03.WildFarm.IO.Contracts;
    public class Writer : IWritable
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
