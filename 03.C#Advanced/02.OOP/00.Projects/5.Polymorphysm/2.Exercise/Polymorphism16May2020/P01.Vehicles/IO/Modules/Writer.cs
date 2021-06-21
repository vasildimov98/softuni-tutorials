namespace P01.Vehicles.IO.Modules
{
    using P01.Vehicles.IO.Contracts;

    public class Writer : IWritable
    {
        public void Write(string text)
        {
            System.Console.Write(text);
        }

        public void WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
