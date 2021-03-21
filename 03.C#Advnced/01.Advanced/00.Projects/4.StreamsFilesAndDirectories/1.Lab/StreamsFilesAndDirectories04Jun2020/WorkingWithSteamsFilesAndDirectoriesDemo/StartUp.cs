namespace WorkingWithSteamsFilesAndDirectoriesDemo
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Size of directory taken by recursion:");
            var megaByte = 1024 * 1024;

            var lengthRecurcion = GetSizeOfDirectoryRecursivly(Environment.CurrentDirectory);
            var lengthInMBRecurcion = lengthRecurcion / megaByte;
            Console.WriteLine(lengthInMBRecurcion);

            Console.WriteLine("Size of directory taken by queue:");

            var lengthQueue = GetSizeOfDirectoryWithQueue(Environment.CurrentDirectory);
            var lengthInMBQueue = lengthQueue / megaByte;
            Console.WriteLine(lengthInMBQueue);

            Console.WriteLine("Size of directory taken by stack:");

            var lengthStack = GetSizeOfDirectoryWithStack(Environment.CurrentDirectory);
            var lengthInMBStack = lengthQueue / megaByte;
            Console.WriteLine(lengthInMBQueue);
        }

        private static double GetSizeOfDirectoryWithStack(string directory)
        {
            var totalLength = 0d;
            var subDirectories = new Stack<string>();

            subDirectories.Push(directory);

            var directories = Directory.GetDirectories(directory);

            foreach (var subDir1 in directories)
            {
                subDirectories.Push(subDir1);

                var newDirectories = Directory.GetDirectories(subDir1);

                foreach (var subDir2 in newDirectories)
                {
                    subDirectories.Push(subDir2);
                }
            }

            var countOfTravelrsal = subDirectories.Count;
            for (int i = 0; i < countOfTravelrsal; i++)
            {
                var subDirectory = subDirectories.Pop();

                var directoryInfo = new DirectoryInfo(subDirectory);

                Console.WriteLine(directoryInfo.Name);

                var filesInFolder = Directory.GetFiles(subDirectory);

                foreach (var file in filesInFolder)
                {
                    var fileInfo = new FileInfo(file);
                    totalLength += fileInfo.Length;
                }
            }

            return totalLength;
        }
        private static double GetSizeOfDirectoryWithQueue(string directory)
        {
            var totalLength = 0d;
            var subDirectories = new Queue<string>();

            subDirectories.Enqueue(directory);

            var directories = Directory.GetDirectories(directory);

            foreach (var subDir1 in directories)
            {
                subDirectories.Enqueue(subDir1);

                var newDirectories = Directory.GetDirectories(subDir1);

                foreach (var subDir2 in newDirectories)
                {
                    subDirectories.Enqueue(subDir2);


                }
            }

            var countOfTraversal = subDirectories.Count;
            for (int i = 0; i < countOfTraversal; i++)
            {
                var subDirectory = subDirectories.Dequeue();

                var directoryInfo = new DirectoryInfo(subDirectory);

                Console.WriteLine(directoryInfo.Name);

                var filesInFolder = Directory.GetFiles(subDirectory);

                foreach (var file in filesInFolder)
                {
                    var fileInfo = new FileInfo(file);
                    totalLength += fileInfo.Length;
                }
            }

            return totalLength;
        }

        private static double GetSizeOfDirectoryRecursivly(string directory)
        {
            var totalLength = 0d;
            var filesInFolder = Directory.GetFiles(directory);

            var directories = Directory.GetDirectories(directory);

            foreach (var folders in directories)
            {
                totalLength += GetSizeOfDirectoryRecursivly(folders);
            }

            foreach (var file in filesInFolder)
            {
                var fileInfo = new FileInfo(file);
                totalLength += fileInfo.Length;
            }

            return totalLength;
        }

        private static void SliceTextAtFourEqualParts()
        {
            var sourceFile = "SliceMe.txt";
            var parts = 4;

            var listOfFiles = new List<string>
            {
                "Part-1.txt",
                "Part-2.txt",
                "Part-3.txt",
                "Part-4.txt"
            };
            var streamFileReader = new FileStream(sourceFile, FileMode.OpenOrCreate, FileAccess.Read);

            var singlePartLength = (int)Math.Ceiling((double)streamFileReader.Length / parts);

            var buffer = new byte[singlePartLength];

            for (int i = 0; i < parts; i++)
            {

                var bytesRead = streamFileReader.Read(buffer, 0, buffer.Length);

                if (bytesRead < buffer.Length)
                {
                    buffer = buffer
                        .Take(bytesRead)
                        .ToArray();
                }

                using var streamFileWrite = new FileStream(listOfFiles[i], FileMode.OpenOrCreate, FileAccess.Write);

                streamFileWrite.Write(buffer, 0, buffer.Length);
            }
        }

        private static void ReadingAndWritingStream()
        {
            using (var reader = new StreamReader("Input.txt"))
            {
                using (var writer = new StreamWriter("Output.txt"))
                {
                    var count = 1;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        writer.WriteLine($"{count++}. {line}");

                        Console.WriteLine($"{count - 1}. {line}");
                    }
                }
            }
        }
    }
}
