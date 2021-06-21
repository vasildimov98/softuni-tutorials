namespace CommandPattern.Models
{
    using CommandPattern.Core.Contracts;
    public class GoodbyeCommad : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Goodbye, {args[0]}";
        }
    }
}
