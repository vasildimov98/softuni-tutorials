namespace Logger.Models.Contracts
{
    using System;
    using global::Logger.Models.Enumerators;

    public interface IError
    {
        DateTime DateTime { get; }
        Level Level { get; }
        string Message { get; }
    }
}
