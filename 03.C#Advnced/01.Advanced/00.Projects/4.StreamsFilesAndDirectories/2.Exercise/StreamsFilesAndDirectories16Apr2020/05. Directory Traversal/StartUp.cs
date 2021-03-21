using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Directory_Traversal
{
    class StartUp
    {
        static void Main()
        {
            var filesDir = Console.ReadLine();

            var files = Directory.GetFiles(filesDir);

            var dirInfo = new Dictionary<string, Dictionary<string, string>>();
            foreach (var fileinfo in files)
            {
                var fileInfo = new FileInfo(fileinfo);

                var fileExtension = fileInfo.Extension;
                var fileName = fileInfo.Name;
                var fileSize = (decimal)fileInfo.Length / 1024; //from bytes to kb;

                if (!dirInfo.ContainsKey(fileExtension))
                {
                    dirInfo[fileExtension] = new Dictionary<string, string>();
                }

                if (!dirInfo[fileExtension].ContainsKey(fileName))
                {
                    dirInfo[fileExtension][fileName] = $"{fileSize:F3}";
                }
            }
            
            var ordered = dirInfo
                .OrderByDescending(a => a.Value.Count)
                .ThenBy(a => a.Key)
                .ToDictionary(k => k.Key, v => v.Value);
            var result = string.Empty;
            foreach (var (extension, filesName) in ordered)
            {
                result += $"{extension}\n";
                Console.WriteLine(extension);
                foreach (var (file, size) in filesName
                    .OrderBy(a => a.Value))
                {
                    result += $"--{file} - {size}kb\n";
                    Console.WriteLine($" --{file} - {size}kb");
                }
            }

            var desktopPath = @"C:\Users\My\Desktop\report.txt";

            File.WriteAllText(desktopPath, result);
        }
    }
}
