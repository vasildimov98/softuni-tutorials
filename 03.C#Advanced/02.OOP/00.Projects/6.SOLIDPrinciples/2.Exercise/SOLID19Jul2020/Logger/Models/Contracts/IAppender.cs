namespace Logger.Models.Contracts
{
    using Models.Enumerators;
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        int MessagesAppended { get; }
        void Append(IError error);
    }
}
