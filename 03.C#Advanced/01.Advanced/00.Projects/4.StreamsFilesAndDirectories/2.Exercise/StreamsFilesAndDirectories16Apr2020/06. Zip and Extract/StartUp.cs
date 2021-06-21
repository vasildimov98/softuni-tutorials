using System;
using System.IO.Compression;

namespace _06._Zip_and_Extract
{
    class StartUp
    {
        static void Main()
        {
            var startPath = @"D:\ZipFile_Demo";
            var zipPath = @"D:\result.zip";
            var extractPath = @"D:\ExtractFile";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
