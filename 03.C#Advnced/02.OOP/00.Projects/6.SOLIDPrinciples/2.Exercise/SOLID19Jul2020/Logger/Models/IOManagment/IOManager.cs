namespace Logger.Models.IOManagment
{
    using System.IO;

    using global::Logger.Models.Contracts;

    public class IOManager : IIOManager
    {
        private string currentPath;

        private string folderName;
        private string fileName;

        private IOManager()
        {
            this.currentPath = this.GetCurrentPath();
        }
        public IOManager(string folderName, string fileName)
            : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }
        public string CurrentDirectoryPath
            => this.currentPath + folderName;

        public string CurrentFilePath
            => this.CurrentDirectoryPath + fileName;

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
        public void EnsureDirectoryPathExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }
        }

        public void EnsureFilePathExist()
        {
            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }

    }
}
