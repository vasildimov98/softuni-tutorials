namespace MortalEngines.IO.Contracts
{
    using System.Windows.Input;
    using System.Collections.Generic;

    public interface IReader
    {
        IList<ICommand> ReadCommands();
    }
}