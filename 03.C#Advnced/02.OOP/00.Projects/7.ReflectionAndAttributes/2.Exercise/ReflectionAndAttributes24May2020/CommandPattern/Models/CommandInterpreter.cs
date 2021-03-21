namespace CommandPattern.Models
{
    using System;
    using System.Linq;
    using System.Reflection;

    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            if (args.Length == 0 || args == null)
            {
                throw new ArgumentException();
            }

            var cmdArgs = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var commandName = cmdArgs[0];
            var commandArgs = cmdArgs.Skip(1).ToArray();

            var assembly = Assembly
                .GetCallingAssembly();

            var type = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower().StartsWith(commandName.ToLower()));

            if (type == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            var instance = (ICommand)Activator.CreateInstance(type);

            return instance.Execute(commandArgs);
        }
    }
}
