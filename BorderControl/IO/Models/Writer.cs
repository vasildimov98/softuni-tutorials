namespace BorderControl.IO.Models
{
    using System;
    using BorderControl.IO.Contracts;
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
