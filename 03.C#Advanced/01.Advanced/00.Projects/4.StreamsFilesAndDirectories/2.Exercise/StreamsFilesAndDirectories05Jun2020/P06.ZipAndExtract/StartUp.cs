namespace P06.ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class StartUp
    {
        private const string FILE_NAME = "copyMe.png";
        private const string RESULT_FILE_NAME = "copyMe.zip";
        public static void Main()
        {
            var desktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            var zipPath = Path.Combine(desktopDirectory, RESULT_FILE_NAME);
            var filePathInDesktop = Path.Combine(desktopDirectory, FILE_NAME);

            DeleteFileIfExits(zipPath);
            DeleteFileIfExits(filePathInDesktop);

            using var archive = ZipFile.Open(zipPath, ZipArchiveMode.Update);
            ArchiveFile(archive);
            ExtractFile(desktopDirectory, archive);
        }

        private static void ExtractFile(string desktopDirectory, ZipArchive archive)
        {
            archive.ExtractToDirectory(desktopDirectory, true);
        }

        private static void ArchiveFile(ZipArchive archive)
        {
            var fileName = Path.GetFileName(FILE_NAME);

            archive.CreateEntryFromFile(FILE_NAME, fileName);
        }

        private static void DeleteFileIfExits(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
