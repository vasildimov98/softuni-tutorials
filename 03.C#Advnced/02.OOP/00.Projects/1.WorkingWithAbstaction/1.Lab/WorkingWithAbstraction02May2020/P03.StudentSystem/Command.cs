﻿namespace P03.StudentSystem
{
    using System.Linq;
    public class Command
    {
        public static Command Parse(string text)
        {
            var parts = text.Split();

            if (parts.Length < 1)
            {
                return null;
            }

            return new Command()
            {
                Name = parts[0],
                Arguments = parts.Skip(1).ToArray()
           };
        }
        public string Name { get; set; }
        public string[] Arguments { get; set; }

    }
}
