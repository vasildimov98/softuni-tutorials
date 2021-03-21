namespace Logger.Models.Appenders
{
    using global::Logger.Models.Contracts;
    using global::Logger.Models.Enumerators;
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }
        public Level Level { get; private set; }
        public IFile File { get; private set; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            var formattedMessage = this.File.Write(this.Layout, error);

            System.IO.File.AppendAllText(this.File.Path, formattedMessage);

            this.MessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}," +
                $" Layout type: {this.Layout.GetType().Name}," +
                $" Report level: {this.Level.ToString().ToUpper()}," +
                $" Messages appended: {this.MessagesAppended}," +
                $" File size: {this.File.Size}";
        }
    }
}
