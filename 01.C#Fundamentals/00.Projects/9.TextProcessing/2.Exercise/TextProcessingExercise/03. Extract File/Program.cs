using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            int lastindex = filePath.LastIndexOf('\\');

            string[] substract = filePath
                .Substring(lastindex + 1)
                .Split('.',StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"File name: {substract[0]}");
            Console.WriteLine($"File extension: {substract[1]}");
        }
    }
}
