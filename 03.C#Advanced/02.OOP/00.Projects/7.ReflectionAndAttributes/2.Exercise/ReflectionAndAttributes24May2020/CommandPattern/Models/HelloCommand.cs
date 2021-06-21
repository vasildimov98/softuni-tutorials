namespace CommandPattern.Models
{
    using System;
    using CommandPattern.Core.Contracts;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException();
            }

            return $"Hello, {args[0]}";
        }
    }
}
