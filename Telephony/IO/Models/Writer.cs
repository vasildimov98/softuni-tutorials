namespace Telephony.IO.Models
{
    using Telephony.IO.Contracts;
    class Writer : IWritable
    {
        public void Write(string text)
        {
            System.Console.Write(text);
        }

        void IWritable.WriteLine(string text)
        {
            System.Console.WriteLine(text);
        }
    }
}
