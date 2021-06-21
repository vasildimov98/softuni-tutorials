namespace P04.MergeFiles
{
    using System.IO;
    public class StartUp
    {
        public static void Main()
        {
            var firstFileName = "FileOneTemp.txt";
            var secondFileName = "FileTwoTemp.txt";
            var outputFileName = "OutputTemp.txt";

            var firsFileLines = File.ReadAllLines(firstFileName);
            var secondFileLines = File.ReadAllLines(secondFileName);

            using var fileWriter = File.CreateText(outputFileName);

            var lineNumber = 0;
            var firstFileLength = firsFileLines.Length;
            var secondFileLength = secondFileLines.Length;

            WriteTextLineByLine(firsFileLines, secondFileLines, fileWriter, lineNumber, firstFileLength, secondFileLength);
        }

        private static void WriteTextLineByLine(string[] firsFileLines, string[] secondFileLines, StreamWriter fileWriter, int lineNumber, int firstFileLength, int secondFileLength)
        {
            while (lineNumber < secondFileLength || lineNumber < firstFileLength)
            {
                TryToWriteLineOnText(firsFileLines, fileWriter, lineNumber, firstFileLength);

                TryToWriteLineOnText(secondFileLines, fileWriter, lineNumber, secondFileLength);

                lineNumber++;
            }
        }

        private static void TryToWriteLineOnText(string[] arr, StreamWriter fileWriter, int lineNumber, int length)
        {
            if (lineNumber < length)
            {
                fileWriter.WriteLine(arr[lineNumber]);
            }
        }
    }
}
