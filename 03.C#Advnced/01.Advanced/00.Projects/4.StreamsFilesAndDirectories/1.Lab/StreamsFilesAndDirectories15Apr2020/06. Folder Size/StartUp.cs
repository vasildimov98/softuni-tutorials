using System;
using System.IO;

namespace _06._Folder_Size
{
    class StartUp
    {
        static void Main()
        {
            var files = Directory.GetFiles("TestFolder");

            var filesSum = 0d;

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                filesSum += fileInfo.Length;
            }

            var filesInMB = filesSum / 1024 / 1024;
            File.WriteAllText("output.txt", filesInMB.ToString());

            string path = @"C:\Users\My\Desktop\Streams, Files and Directories - Lab";
            PrintFiles(path, string.Empty);
        }

        static void PrintFiles(string path, string prefix)
        {
            var directories = Directory.GetDirectories(path);

            var directoryInfo = new DirectoryInfo(path);
            Console.WriteLine($"{prefix}Dir: {directoryInfo.Name}");

            foreach (var directory in directories)
            {
                PrintFiles(directory, prefix += "--");
            }

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                Console.WriteLine($"{prefix}-File: {fileInfo.Name}");
            }
        }
    }
}
