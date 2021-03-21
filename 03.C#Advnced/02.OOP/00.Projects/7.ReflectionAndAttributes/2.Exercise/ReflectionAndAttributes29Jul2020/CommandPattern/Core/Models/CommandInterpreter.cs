namespace CommandPattern.Core.Models
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            var commandArgs = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var commandName = commandArgs[0];

            var assembly = Assembly
               .GetCallingAssembly();

            var classType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower().StartsWith(commandName.ToLower()));

            var instance = (ICommand)Activator.CreateInstance(classType);

            return instance.Execute(commandArgs.Skip(1).ToArray());
        }
    }
}
