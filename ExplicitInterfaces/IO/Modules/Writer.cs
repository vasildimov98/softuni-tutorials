namespace ExplicitInterfaces.IO.Modules
{
    using ExplicitInterfaces.IO.Contracts;
    public class Writer : IWritable
    {
        public void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
