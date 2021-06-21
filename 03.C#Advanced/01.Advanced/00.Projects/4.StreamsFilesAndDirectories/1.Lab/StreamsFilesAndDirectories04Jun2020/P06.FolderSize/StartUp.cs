namespace P06.FolderSize
{
    using System;
    using System.IO;
    public class StartUp
    {
        public static void Main()
        {
            const int MEGABYTES = 1024 * 1024;

            const string OUTPUT_FILE_NAME = "Output.txt";

            var directories = Directory
                .GetDirectories(Environment
                .CurrentDirectory);

            var totalSize = 0d;

            foreach (var directory in directories)
            {
                totalSize = GetSizeOfFilesInDirectory(directory);
            }

            var sizeInMB = totalSize / MEGABYTES;

            File.WriteAllText(OUTPUT_FILE_NAME, sizeInMB.ToString());
        }

        private static double GetSizeOfFilesInDirectory(string directory)
        {
            var totalSize = 0d;

            var directoryFiles = Directory.GetFiles(directory);

            foreach (var file in directoryFiles)
            {
                var fileInfo = new FileInfo(file);

                totalSize += fileInfo.Length;
            }

            return totalSize;
        }
    }
}
