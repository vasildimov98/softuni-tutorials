namespace Logger.Models.Files
{
    using System;
    using System.IO;
    using System.Linq;

    using global::Logger.Models.Contracts;
    using global::Logger.Models.IOManagment;
   
    public class LogFile : IFile
    {
        private IOManager IOManager;

        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
            this.IOManager.EnsureDirectoryPathExist();
            this.IOManager.EnsureFilePathExist();
        }
        public string Path => this.IOManager.CurrentFilePath;

        public long Size => this.GetFileSize();

        public string Write(ILayout layout, IError error)
        {
            var format = layout.Format;

            var dateTime = error.DateTime;
            var level = error.Level;
            var message = error.Message;

            var formattedMessage = string.Format(format,
              dateTime.ToString("M/dd/yyyy h:mm:ss tt"),
              level.ToString(),
              message) + Environment.NewLine;


            return formattedMessage;
        }

        private long GetFileSize()
        {
            return File.ReadAllText(this.Path)
                .Where(ch => char.IsLetter(ch))
                .Sum(ch => ch);
        }
    }
}
