namespace P05.DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    public class StartUp
    {
        private const int ONE_KILO_BYTES = 1024;
        private const string PATH_UP_SYMBOL = "..";
        private const string OUTPUT_FILE_NAME = "report.txt";

        private static SortedDictionary<string, SortedDictionary<string, decimal>> filesMapCollection;
        public static void Main()
        {
            filesMapCollection = new SortedDictionary<string, SortedDictionary<string, decimal>>();

            var pathToRead = Path.Combine(PATH_UP_SYMBOL, PATH_UP_SYMBOL, PATH_UP_SYMBOL);

            var filesInfo = Directory.GetFiles(pathToRead);

            MapFilesIntoCategories(filesInfo);

            var report = GetReport();

            WriteReportOnDesktop(report);
        }

        private static void WriteReportOnDesktop(string report)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var pathToWrite = Path.Combine(desktopPath, OUTPUT_FILE_NAME);

            File.WriteAllText(pathToWrite, report);
        }
        private static string GetReport()
        {
            var sb = new StringBuilder();

            foreach (var (extension, filesInfo) in filesMapCollection
                .OrderByDescending(f => f.Value.Count))
            {
                sb.AppendLine(extension);

                foreach (var (fileName, fileSize) in filesInfo
                    .OrderBy(f => f.Value))
                {
                    sb.AppendLine($"--{fileName} - {fileSize}kb");
                }
            }

            return sb.ToString().TrimEnd();
        }
        private static void MapFilesIntoCategories(string[] filesInfo)
        {
            foreach (var file in filesInfo)
            {
                var fileInfo = new FileInfo(file);

                var fileExtensions = fileInfo
                    .FullName
                    .Split('.')
                    .TakeLast(1)
                    .ToArray()[0];

                var fileName = fileInfo.Name;

                var fileSizeInKB = (decimal)fileInfo.Length / ONE_KILO_BYTES;

                var roundedFileSize = Math.Round(fileSizeInKB, 3, MidpointRounding.AwayFromZero);

                if (!filesMapCollection.ContainsKey(fileExtensions))
                {
                    filesMapCollection[fileExtensions] = new SortedDictionary<string, decimal>();
                }

                filesMapCollection[fileExtensions][fileName] = roundedFileSize;
            }
        }
    }
}
