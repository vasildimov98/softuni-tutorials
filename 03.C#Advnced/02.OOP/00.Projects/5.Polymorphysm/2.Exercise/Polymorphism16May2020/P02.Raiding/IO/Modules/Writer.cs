namespace P02.Raiding.IO.Modules
{
    using System;

    using P02.Raiding.IO.Contracts;
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
